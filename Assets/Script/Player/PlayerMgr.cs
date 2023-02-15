using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : Singleton<PlayerMgr>
{
    public void SaveRolesInfo(RolesInfo rolesInfo)
    {
        PlayerData.Instance.rolesInfo = rolesInfo;
    }

    public RolesInfo GetRolesInfo()
    {
        return PlayerData.Instance.rolesInfo;
    }

    public void SaveRoomInfo(RoomInfo roomInfo)
    {
        PlayerData.Instance.roomInfo = roomInfo;
    }

    public void RemoveRoomInfo(RoomInfo roomInfo)
    {
        PlayerData.Instance.roomInfo = null;
    }
}
