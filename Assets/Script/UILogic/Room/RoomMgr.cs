using Google.Protobuf.Collections;
using ProtoMsg;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMgr : Singleton<RoomMgr>
{
    public void SaveRoomInfo(RoomInfo roomInfo)
    {
        PlayerData.Instance.roomInfo = roomInfo;
    }

    public void RemoveRoomInfo()
    {
        PlayerData.Instance.roomInfo = null;
    }

    public RoomInfo GetRoomInfo()
    {
        return PlayerData.Instance.roomInfo;
    }
    /// <summary>
    /// 获取阵营信息
    /// </summary>
    /// <param name="rolesID"></param>
    /// <returns></returns>
    public int GetTeamID(int rolesID)
    {
        for (int i = 0; i < PlayerData.Instance.roomInfo.TeamA.Count; i++)
        {
            if (PlayerData.Instance.roomInfo.TeamA[i].RolesID == rolesID)
            {
                return 0;
            }
        }
        return 1;
    }

    public string GetNickName(int rolesID)
    {
        for (int i = 0; i<PlayerData.Instance.roomInfo.TeamA.count; i++)
        {
            if (PlayerData.Instance.roomInfo.TeamA[i].RolesID == rolesID)
            {
                return PlayerData.Instance.roomInfo.TeamA[i].NickName;
            }
            if (PlayerData.Instance.roomInfo.TeamB[i].RolesID == rolesID)
            {
                return PlayerData.Instance.roomInfo.TeamB[i].NickName;
            }
        }
        return "";
    }
    /// <summary>
    /// 保存所有角色信息
    /// </summary>
    /// <param name="playerInfos"></param>
    public void SavePlayerInfo(RepeatedField<PlayerInfo> playerInfos)
    {
        RoomData.Instance.playerinfos = playerInfos;
    }
}
