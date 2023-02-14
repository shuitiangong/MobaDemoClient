using Game.Net;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public static USocket uSocket;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        uSocket = new USocket(DispatchNetEvent);
        //打开登录界面
        UIMgr.Instance.OpenWindow(WindowType.LoginWindow);
    }


    void Update()
    {
        if (uSocket != null)
        {
            uSocket.Handle();
        }
        //调用UI管理里面的Update
    }

    void DispatchNetEvent(BufferEntity buffer)
    {
        //进行报文分发
        NetEvent.Instance.Dispatch(buffer.messageID, buffer);
    }
}
