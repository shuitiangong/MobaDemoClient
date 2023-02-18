using ProtoMsg;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFSM 
{
    public Transform transform;
    public PlayerFSM fsm; //管理类

    //进入状态
    public virtual void Enter() {
        AddListener();
    }

    //状态更新中
    public virtual void Update() { 
    
    }

    //退出状态
    public virtual void Exit() {
        RemoveListener();
    }

    //监听一些游戏事件
    public virtual void AddListener() { 
    
    }

    //移除掉监听的事件
    public virtual void RemoveListener()
    {

    }

    //处理每一帧的网络事件
    public virtual void HandleCMD(BattleUserInputS2C s2cMSG)
    {

    }
}
