using Google.Protobuf;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Net
{
    public class BufferFactory
    {
        enum MessageType
        {
            ACK = 0, //确认报文
            Logic = 1, //业务逻辑的报文
        }
        /// <summary>
        /// 创建并且发送报文
        /// </summary>
        /// <param name="messageID"></param>
        /// <param name="message"></param>
        public static BufferEntity CreateAndSendPackage(int messageID, IMessage message)
        {
            JsonHelper.Log(messageID, message);
            BufferEntity buffer = new BufferEntity(USocket.local.endPoint, USocket.local.sessionID,
                0, 0, MessageType.Logic.GetHashCode(), messageID, ProtobufHelper.ToBytes(message));
            USocket.local.Send(buffer);
            return buffer;
        }
    }
}

