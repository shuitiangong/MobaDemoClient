using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleConfig : Singleton<BattleConfig>
{
    //BattleSceneConfig 
    //10个英雄的位置 角度
    //野区野怪的配置 防御塔的配置 ==

    /// <summary>
    /// 出生的位置
    /// </summary>
    public Vector3[] spawnPosition = new Vector3[10] { 
        //A队伍的位置 0-4
        new Vector3(-6.52f,0,-8.96f),
        new Vector3(-2.26f,0,-3.71f),
        new Vector3(-6.71f,0,-4.01f ),
        new Vector3(-4.28f,0,-5.89f ),
        new Vector3(-2.02f,0,-8.23f), 
        //B队伍的位置 5-9
        new Vector3(-95.198f,0,-96.542f),
        new Vector3(-99.892f,0,-101.4f ),
        new Vector3(-95.432f,0,-101.49f),
        new Vector3(-97.692f,0,-99.409f),
        new Vector3(-99.7443f,0,-96.884f), 
    };

    /// <summary>
    /// 初始的角度
    /// </summary>
    public Vector3[] spawnRotation = new Vector3[10] {
        //A队伍的角度
        new Vector3(0,242.49f,0),
        new Vector3(0,-122.251f,0),
        new Vector3( 0,-152.659f,0 ),
        new Vector3(0,230.56f,0),
        new Vector3( 0,-149.089f,0 ),

        //B队伍的角度
        new Vector3(0,67.403f,0 ),
        new Vector3(0,-297.338f,0 ),
        new Vector3( 0,-327.746f,0),
        new Vector3(0,55.473f,0),
        new Vector3(0,-324.176f,0), 
    };
}
