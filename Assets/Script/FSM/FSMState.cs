using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FSMState 
{
   None,//空
   Idle,//休闲
   Move,//跑
   Skill,//技能中
   Dead,//死亡
   Relive,//复活
}