using ProtoMsg;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 角色有限状态机的管理类
/// </summary>
public class PlayerFSM : MonoBehaviour
{
    Dictionary<FSMState, EntityFSM> playerState = new Dictionary<FSMState, EntityFSM>();
    FSMState currentState = FSMState.None;
    public PlayerCtrl playerCtrl;
    public NavMeshAgent agent; //寻路导航的组件
    public BattleUserInputS2C moveCMD;
    public BattleUserInputS2C skillCMD;
    public void Init(PlayerCtrl playerCtrl) 
    {
        this.playerCtrl = playerCtrl;
        agent = transform.GetComponent<NavMeshAgent>();
        ToNext(FSMState.Idle);
        playerState[FSMState.Idle] = new PlayerIdle(transform, this);
        playerState[FSMState.Move] = new PlayerMove(transform, this);
        playerState[FSMState.Skill] = new PlayerSkill(transform, this);
        playerState[FSMState.Dead] = new PlayerDead(transform, this);
        playerState[FSMState.Relive] = new PlayerRelive(transform, this);

        ToNext(FSMState.Idle);
    }

    private void Update()
    {
        if (currentState != FSMState.None)
        {
            playerState[currentState].Update();
        }
    }
    /// <summary>
    /// 切换到下一个状态
    /// </summary>
    /// <param name="nextState"></param>
    public void ToNext(FSMState nextState) {
        if (currentState!=FSMState.None)
        {
            playerState[currentState].Exit();
        }
        playerState[nextState].Enter();
        currentState = nextState;
    }

    /// <summary>
    /// 处理每一帧网络事件
    /// </summary>
    /// <param name="s2cMSG"></param>
    public void HandleCMD(BattleUserInputS2C s2cMSG)
    {
        playerState[currentState].HandleCMD(s2cMSG);
    }
}
