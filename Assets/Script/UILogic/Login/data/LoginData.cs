using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginData : Singleton<LoginData>
{
    private RolesInfo rolesInfo;
    internal void SetRolesInfo(RolesInfo ro)
    {
        rolesInfo = ro;
    }
}
