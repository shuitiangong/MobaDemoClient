using Game.Net;
using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleListener : Singleton<BattleListener>
{
    Queue<BattleUserInputS2C> awaitHandle;
    public void Init()
    {
        awaitHandle = new Queue<BattleUserInputS2C>();
        NetEvent.Instance.AddEventListener(1500, HandleBattleUserInputS2C);
    }

    public void Release()
    {
        NetEvent.Instance.RemoveEventListener(1500, HandleBattleUserInputS2C);
        awaitHandle.Clear();
    }

    
    private void HandleBattleUserInputS2C(BufferEntity res)
    {
        BattleUserInputS2C s2cMSG = ProtobufHelper.FromBytes<BattleUserInputS2C>(res.proto);
        awaitHandle.Enqueue(s2cMSG);
    }

    public void PlayerFrame(Action<BattleUserInputS2C> action)
    {
        if (action!=null && awaitHandle.Count>0)
        {
            action(awaitHandle.Dequeue());
        }
    }
}
