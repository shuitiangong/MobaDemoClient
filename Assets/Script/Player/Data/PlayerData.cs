using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : Singleton<PlayerData>
{
    private RolesInfo rolesInfo = null;
    public void SaveRolesInfo(RolesInfo rolesInfo)
    {
        this.rolesInfo = rolesInfo;
    }
}
