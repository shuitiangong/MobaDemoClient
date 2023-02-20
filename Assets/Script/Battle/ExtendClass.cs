using ProtoMsg;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtendClass
{
    //Vector3 ->V3Info
    public static V3Info ToV3Info(this Vector3 vector3)
    {
        V3Info v3Info = new V3Info();
        v3Info.X = (int)(vector3.x * 1000);
        v3Info.Y = (int)(vector3.y * 1000);
        v3Info.Z = (int)(vector3.z * 1000);
        return v3Info;
    }


    //V3Info-Vector3
    public static Vector3 ToVector3(this V3Info v3Info)
    {
        Vector3 v = new Vector3();
        v.x = (int)(v3Info.X / 1000);
        v.y = (int)(v3Info.Y / 1000);
        v.z = (int)(v3Info.Z / 1000);
        return v;
    }
}
