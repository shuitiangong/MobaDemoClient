using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProtoMsg;
using UnityEngine;

public class PlayerDead : EntityFSM
{
    public PlayerDead(Transform transform, PlayerFSM fsm)
    {
        this.transform = transform;
        this.fsm = fsm;
    }

    public override void AddListener()
    {
        base.AddListener();
    }

    public override void Enter()
    {
        base.Enter();
        fsm.playerCtrl.animatorMgr.Play(PlayerAnimationClip.Dead);
        //进入到复活状态
        Quit();
    }

    private async void Quit()
    {
        await Task.Delay(5000);
        //复活状态
        fsm.ToNext(FSMState.Relive);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void HandleCMD(BattleUserInputS2C s2cMSG)
    {
        base.HandleCMD(s2cMSG);
    }

    public override void RemoveListener()
    {
        base.RemoveListener();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void HandleMoveEvent(BattleUserInputS2C s2cMSG)
    {
        base.HandleMoveEvent(s2cMSG);
    }

    public override void HandleSkillEvent(BattleUserInputS2C s2cMSG)
    {
        base.HandleSkillEvent(s2cMSG);
    }
}
