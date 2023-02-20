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
        if (s2cMSG.CMD.Key == KeyCode.A.GetHashCode())
        {
            HandleSkillEvent(s2cMSG);
        }
        else if (s2cMSG.CMD.Key == KeyCode.Q.GetHashCode())
        {
            HandleSkillEvent(s2cMSG);
        }
        else if (s2cMSG.CMD.Key == KeyCode.W.GetHashCode())
        {
            HandleSkillEvent(s2cMSG);
        }
        else if (s2cMSG.CMD.Key == KeyCode.E.GetHashCode())
        {
            HandleSkillEvent(s2cMSG);
        }
        else if (s2cMSG.CMD.Key == KeyCode.R.GetHashCode())
        {
            HandleSkillEvent(s2cMSG);
        }
        else if (s2cMSG.CMD.Key == KeyCode.D.GetHashCode())
        {
            HandleSkillEvent(s2cMSG);
        }
        else if (s2cMSG.CMD.Key == KeyCode.F.GetHashCode())
        {
            HandleSkillEvent(s2cMSG);
        }
        else if (s2cMSG.CMD.Key == KeyCode.B.GetHashCode())
        {
            HandleSkillEvent(s2cMSG);
        }
        else if (s2cMSG.CMD.Key == KeyCode.Mouse1.GetHashCode())
        {
            //移动 
            HandleMoveEvent(s2cMSG);
        }
        //鼠标左键 选择人物 
    }

    public virtual void HandleMoveEvent(BattleUserInputS2C s2cMSG)
    {
        fsm.moveCMD = s2cMSG;
    }

    public virtual void HandleSkillEvent(BattleUserInputS2C s2cMSG)
    {
        fsm.skillCMD = s2cMSG;
    }
}
