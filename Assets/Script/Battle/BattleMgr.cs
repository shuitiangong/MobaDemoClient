using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMgr : MonoBehaviour
{
    private void Awake()
    {
        foreach (var playerInfo in RoomData.Instance.playerinfos)
        {
            GameObject hero = ResMgr.Instance.LoadModel($"Hero/{playerInfo.HeroID}/Model/{playerInfo.HeroID}");
            hero.transform.position = BattleConfig.Instance.spawnPosition[playerInfo.PosID];
            hero.transform.eulerAngles = BattleConfig.Instance.spawnRotation[playerInfo.PosID];

            PlayerCtrl playerCtrl = hero.AddComponent<PlayerCtrl>();
            RoomMgr.Instance.SavePlayerCtrl(playerInfo.RolesInfo.RolesID, playerCtrl);
            RoomMgr.Instance.SavePlayerObjects(playerInfo.RolesInfo.RolesID, hero);
            //初始化每个角色
            playerCtrl.Init(playerInfo);
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnDestroy()
    {
        RoomMgr.Instance.CloseRoom();
    }
}
