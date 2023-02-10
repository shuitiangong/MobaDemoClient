using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Game.Net
{
    //网络客户端代理
    public class UClient
    {
        public IPEndPoint endPoint;
        USocket uSocket;
        public int sessionID;
        public int sendSN = 0; //发送序号
        public int handleSN = 0; //处理的序号 为了保证报文的顺序性
        int overtime = 150; //超时重传时间（毫秒）
        Action<BufferEntity> handleAction; //处理报文的函数 实际就是分发报文给各个游戏模块
        ConcurrentDictionary<int, BufferEntity> sendPackage = new ConcurrentDictionary<int, BufferEntity>(); //缓存已经发送的报文
        ConcurrentDictionary<int, BufferEntity> waitHandle = new ConcurrentDictionary<int, BufferEntity>(); //缓存已经发送的报文


        public UClient(USocket uSocket, IPEndPoint endPoint, int sendSN, int handleSN, int sessionID, Action<BufferEntity> dispatchNetEvent)
        {
            this.uSocket = uSocket;
            this.endPoint = endPoint;
            this.sendSN = sendSN;
            this.handleSN = handleSN;
            this.sessionID = sessionID;
            handleAction = dispatchNetEvent;
            CheckOutTIme();
        }

        //处理消息：按照报文的序号 进行顺序处理 如果是收到超过当前顺序+1的报文 先进行缓存
        public void Handle(BufferEntity buffer)
        {
            if (this.sessionID==0 && buffer.session!=0)
            {
                this.sessionID = buffer.session;
            }
            switch(buffer.messageType)
            {
                case 0: //ACK确认报文
                    BufferEntity bufferEntity;
                    if (sendPackage.TryRemove(buffer.sn, out bufferEntity))
                    {
                        Debug.Log($"收到ACK确认报文，序号是：{buffer.sn}");
                    }
                    break;
                case 1: //业务报文
                    BufferEntity ackPackage = new BufferEntity(buffer);
                    uSocket.SendACK(ackPackage); //先告诉服务器 我已经收到这个报文
                    HandleLogicPackage(buffer);
                    break;
                default:
                    break;
            }
        }

        //处理业务报文
        private void HandleLogicPackage(BufferEntity buffer)
        {
            if (buffer.sn <= handleSN)
            {
                return;
            }
            if (buffer.sn - handleSN>1)
            {
                if (waitHandle.TryAdd(buffer.sn, buffer))
                {
                    Debug.Log($"收到错序的报文:{buffer.sn}");
                }
                return;
            }
            //更新已处理的报文
            handleSN = buffer.sn;
            if (handleAction!=null)
            {
                handleAction(buffer);
            }
            BufferEntity nextBuffer;
            //判断缓冲区有没有存下一条数据
            if (waitHandle.TryRemove(handleSN+1, out nextBuffer))
            {
                HandleLogicPackage(nextBuffer);
            }
        }

        public void Send(BufferEntity package)
        {
            package.time = TimeHelper.Now();
            sendSN++;
            package.sn = sendSN;
            package.Encoder(false);
            if (sessionID != 0)
            {
                //缓存起来 因为可能需要重发
                sendPackage.TryAdd(sendSN, package);
            }
            else
            {
                //还没和服务器建立链接 不需要缓存
            }
            uSocket.Send(package.buffer, endPoint);
        }

        public async void CheckOutTIme()
        {
            await Task.Delay(overtime);
            foreach (var package in sendPackage.Values)
            {
                //确认是不是超过最大发送时间
                if (TimeHelper.Now()-package.time > overtime*10)
                {
                    OnDisconnect();
                    return;
                }
                //确认是不是超过最大发送次数
                if (TimeHelper.Now()-package.time > (package.recurCount+1)*overtime)
                {
                    package.recurCount++;
                    uSocket.Send(package.buffer, endPoint);
                }
            }
            CheckOutTIme();
        }

        public void OnDisconnect()
        {
            handleAction = null;
            uSocket.Close();
        }
    }
}

