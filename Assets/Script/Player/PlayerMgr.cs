using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMgr : Singleton<PlayerMgr>
{
    public void SaveRolesInfo(RolesInfo rolesInfo)
    {
        PlayerData.Instance.SaveRolesInfo(rolesInfo);
    }
}
