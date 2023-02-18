using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMgr : MonoBehaviour
{
    private Dictionary<int, PlayerCtrl> playerCtrlDic;
    private Dictionary<int, GameObject> playerObjects;
    private void Awake()
    {
        playerCtrlDic = new Dictionary<int, PlayerCtrl>();
        playerObjects = new Dictionary<int, GameObject>();
        foreach (var playerInfo in RoomData.Instance.playerinfos)
        {
            GameObject hero = ResMgr.Instance.LoadModel($"Hero/{playerInfo.HeroID}/Model/{playerInfo.HeroID}");
            hero.transform.position = BattleConfig.Instance.spawnPosition[playerInfo.PosID];
            hero.transform.eulerAngles = BattleConfig.Instance.spawnRotation[playerInfo.PosID];

            PlayerCtrl playerCtrl = hero.AddComponent<PlayerCtrl>();
            playerCtrlDic[playerInfo.RolesInfo.RolesID] = playerCtrl;
            playerObjects[playerInfo.RolesInfo.RolesID] = hero;
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
        if (playerCtrlDic!=null)
        {
            playerCtrlDic.Clear();
            playerCtrlDic = null;
        }
        if (playerObjects != null)
        {
            playerObjects.Clear();
            playerObjects = null;
        }
    }
}
