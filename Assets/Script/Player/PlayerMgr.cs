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

    /// <summary>
    /// 检查是否是自己的角色
    /// </summary>
    /// <param name="rolesID"></param>
    /// <returns></returns>
    public bool CheckIsSelfRoles(int rolesID)
    {
        return PlayerData.Instance.rolesInfo.RolesID == rolesID;
    }

}
