using Google.Protobuf.Collections;
using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomData : Singleton<RoomData>
{
    public RepeatedField<PlayerInfo> playerinfos;
    public Dictionary<int, PlayerCtrl> playerCtrlDic;
    public Dictionary<int, GameObject> playerObjects;
    public Dictionary<int, HeroAttributeEntity> heroCurrentAtt;
    public Dictionary<int, HeroAttributeEntity> heroTotalAtt;
    public void Init()
    {
        playerCtrlDic = new Dictionary<int, PlayerCtrl>();
        playerObjects = new Dictionary<int, GameObject>();
        heroCurrentAtt = new Dictionary<int, HeroAttributeEntity>();
        heroTotalAtt = new Dictionary<int, HeroAttributeEntity>();
    }

    public void Clear()
    {
        if (playerCtrlDic!=null)
        {
            playerCtrlDic.Clear();
            playerCtrlDic = null;
        }
        if (playerObjects!=null)
        {
            playerObjects.Clear();
            playerObjects = null;
        }
        if (heroCurrentAtt!=null)
        {
            heroCurrentAtt.Clear();
            heroCurrentAtt = null;
        }
        if (heroTotalAtt!=null)
        {
            heroTotalAtt.Clear();
            heroTotalAtt = null;
        }
    }
}
