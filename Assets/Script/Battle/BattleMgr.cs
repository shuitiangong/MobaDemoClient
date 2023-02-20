using ProtoMsg;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMgr : MonoBehaviour
{
    private bool isInit;
    Dictionary<int, PlayerCtrl> playerCtrlDic;
    private void Awake()
    {
        isInit = false;
        playerCtrlDic = new Dictionary<int, PlayerCtrl>();
        foreach (var playerInfo in RoomData.Instance.playerinfos)
        {
            GameObject hero = ResMgr.Instance.LoadModel($"Hero/{playerInfo.HeroID}/Model/{playerInfo.HeroID}");
            hero.transform.position = BattleConfig.Instance.spawnPosition[playerInfo.PosID];
            hero.transform.eulerAngles = BattleConfig.Instance.spawnRotation[playerInfo.PosID];

            PlayerCtrl playerCtrl = hero.AddComponent<PlayerCtrl>();
            RoomMgr.Instance.SavePlayerCtrl(playerInfo.RolesInfo.RolesID, playerCtrl);
            RoomMgr.Instance.SavePlayerObjects(playerInfo.RolesInfo.RolesID, hero);
            //初始化每个角色 挂载控制器
            playerCtrl.Init(playerInfo);
        }

        this.gameObject.AddComponent<InputCtrl>();
        isInit = true;
    }

    public void HandleCMD(BattleUserInputS2C s2cMSG)
    { 
        //先确定发送命令的玩家
        //调用其角色控制器 处理这个事件
        playerCtrlDic[s2cMSG.CMD.RolesID].playerFSM.HandleCMD(s2cMSG);

    }

    private void Update()
    {
        if (isInit) 
        {
            BattleListener.Instance.PlayerFrame(HandleCMD);
        }
    }

    private void OnDestroy()
    {
        RoomMgr.Instance.CloseRoom();
    }
}
