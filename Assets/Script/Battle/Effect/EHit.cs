using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EHit : MonoBehaviour
{
    bool isDestroy = false;

    EConfig eConfig;
    //碰撞:角色

    //所有的特效都采用物理触发机制 而非碰撞 避免使用物理效果带来的bug
    public void OnTriggerEnter(Collider other)
    {
        if (eConfig==null)
        {
            return;
        }

        if (eConfig.hitAction!=null)
        {
            eConfig.hitAction(eConfig, other.gameObject);
        }
        //判断 如果不是同个阵营的 就产生爆炸 设置爆炸物体的生层位置 等于碰撞点的位置
        //然后通知属性管理器控制掉血
      
        //不同的ID 触发的效果可能不一样!

        ////角色
        //if (other.CompareTag("Player"))
        //{
        //    //判断是否同个阵营的
        //    bool isOneTeam= RoomData.Instance.CheckOneTeam(eConfig.releaserID, other.GetComponent<PlayerCtrl>().playerInfo.RolesInfo.RolesID);
        //    if (isOneTeam==false)
        //    {
        //        //如果不是同个阵营的 扣血
        //        other.GetComponent<PlayerCtrl>().OnSkillHit(50);
        //        if (eConfig.destroyMode == DestroyMode.OnHit_DifferentCampPlayer || eConfig.destroyMode == DestroyMode.OnHit_AllPlayer)
        //        {
        //            //并且销毁
        //            Destroy(eConfig.gameObject);
        //            isDestroy = true;
        //        }
        //    }
        //    else
        //    {
        //        //如果是同个阵营的
        //        return;
        //    }
        //}
        ////野怪
        //else if (other.CompareTag("Monster"))
        //{
        //    //让他扣血 并且让它进入对应的状态
        //}
        ////兵
        //else if (other.CompareTag("Soldier"))
        //{
        //    //如果不是同个阵营 让他扣血 并且让它进入对应的状态
        //}
        ////防御塔或者水晶
        //else if (other.CompareTag("Tower"))
        //{
        //    //如果不是同个阵营 让他扣血 并且让它进入对应的状态
        //}
        ////水晶
        //else if (other.CompareTag("Crystal"))
        //{
        //    //如果不是同个阵营 让他扣血 并且让它进入对应的状态
        //}

        ////克隆爆炸特效
        //if (isDestroy&&eConfig.hitLoad !=null)
        //{
        //    //克隆爆炸物
        //    GameObject hitObj= GameObject.Instantiate(eConfig.hitLoad);
        //    hitObj.transform.position = this.transform.position;
        //    //hitObj.transform.eulerAngles=
        //}
    }


    internal void Init(EConfig eConfig)
    {
        this.eConfig = eConfig;
    }
}
