using Game.Net;
using ProtoMsg;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    USocket uSocket;
    // Start is called before the first frame update
    void Start()
    {
        uSocket = new USocket(DispatchNetEvent);
        UserInfo userInfo = new UserInfo();
        userInfo.Account = "111111";
        userInfo.Password = "123456";
        
        UserRegisterC2S userRegisterC2S = new UserRegisterC2S();
        userRegisterC2S.UserInfo = userInfo;
        BufferEntity bufferEntity = BufferFactory.CreateAndSendPackage(1001, userInfo);
    }

    private void DispatchNetEvent(BufferEntity buffer)
    {
        //进行报文分发
    }

    // Update is called once per frame
    void Update()
    {
        if (uSocket!=null)
        {
            uSocket.Handle();
        }
    }
}
