using Game.Net;
using Game.View;
using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RolesMgr: Singleton<RolesMgr>
{
    public void SaveRolesInfo(RolesInfo rolesInfo)
    {
        PlayerMgr.Instance.SaveRolesInfo(rolesInfo);
    }
}
