
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class AllSkillConfig
{

    static AllSkillConfig()
    {
        
       AllSkillEntity AllSkillEntity0 = new AllSkillEntity();
       AllSkillEntity0.ID = 101;
       AllSkillEntity0.SkillName = @"惩戒";
       AllSkillEntity0.Info = @"惩戒可以对野怪或者小兵造成180伤害";
       AllSkillEntity0.CoolingTime = 180f;
       AllSkillEntity0.SkillType = 1;
       AllSkillEntity0.AttackDistance = -1f;

        if (!entityDic.ContainsKey(AllSkillEntity0.ID))
        {
          entityDic.Add(AllSkillEntity0.ID, AllSkillEntity0);
        }

       AllSkillEntity AllSkillEntity1 = new AllSkillEntity();
       AllSkillEntity1.ID = 102;
       AllSkillEntity1.SkillName = @"传送";
       AllSkillEntity1.Info = @"传送可以将英雄送到友军目标附近";
       AllSkillEntity1.CoolingTime = 180f;
       AllSkillEntity1.SkillType = 0;
       AllSkillEntity1.AttackDistance = 4f;

        if (!entityDic.ContainsKey(AllSkillEntity1.ID))
        {
          entityDic.Add(AllSkillEntity1.ID, AllSkillEntity1);
        }

       AllSkillEntity AllSkillEntity2 = new AllSkillEntity();
       AllSkillEntity2.ID = 103;
       AllSkillEntity2.SkillName = @"点燃";
       AllSkillEntity2.Info = @"3秒内对敌方共造成150真实伤害(50/每秒)";
       AllSkillEntity2.CoolingTime = 180f;
       AllSkillEntity2.SkillType = 0;
       AllSkillEntity2.AttackDistance = -1f;

        if (!entityDic.ContainsKey(AllSkillEntity2.ID))
        {
          entityDic.Add(AllSkillEntity2.ID, AllSkillEntity2);
        }

       AllSkillEntity AllSkillEntity3 = new AllSkillEntity();
       AllSkillEntity3.ID = 104;
       AllSkillEntity3.SkillName = @"净化";
       AllSkillEntity3.Info = @"净化可以解除身上的负面效果";
       AllSkillEntity3.CoolingTime = 180f;
       AllSkillEntity3.SkillType = 0;
       AllSkillEntity3.AttackDistance = -1f;

        if (!entityDic.ContainsKey(AllSkillEntity3.ID))
        {
          entityDic.Add(AllSkillEntity3.ID, AllSkillEntity3);
        }

       AllSkillEntity AllSkillEntity4 = new AllSkillEntity();
       AllSkillEntity4.ID = 105;
       AllSkillEntity4.SkillName = @"屏障";
       AllSkillEntity4.Info = @"屏障可以给自己临时增加一个护盾,3秒内可以抵抗200伤害";
       AllSkillEntity4.CoolingTime = 180f;
       AllSkillEntity4.SkillType = 0;
       AllSkillEntity4.AttackDistance = -1f;

        if (!entityDic.ContainsKey(AllSkillEntity4.ID))
        {
          entityDic.Add(AllSkillEntity4.ID, AllSkillEntity4);
        }

       AllSkillEntity AllSkillEntity5 = new AllSkillEntity();
       AllSkillEntity5.ID = 106;
       AllSkillEntity5.SkillName = @"闪现";
       AllSkillEntity5.Info = @"瞬间向指定方向传送一小段距离,最大为2米,如无法穿越障碍物,则会发生撞墙事故!";
       AllSkillEntity5.CoolingTime = 180f;
       AllSkillEntity5.SkillType = 0;
       AllSkillEntity5.AttackDistance = 4f;

        if (!entityDic.ContainsKey(AllSkillEntity5.ID))
        {
          entityDic.Add(AllSkillEntity5.ID, AllSkillEntity5);
        }

       AllSkillEntity AllSkillEntity6 = new AllSkillEntity();
       AllSkillEntity6.ID = 107;
       AllSkillEntity6.SkillName = @"虚弱";
       AllSkillEntity6.Info = @"虚弱可以让对方的英雄持续2秒减少移动速度50%";
       AllSkillEntity6.CoolingTime = 180f;
       AllSkillEntity6.SkillType = 0;
       AllSkillEntity6.AttackDistance = 4f;

        if (!entityDic.ContainsKey(AllSkillEntity6.ID))
        {
          entityDic.Add(AllSkillEntity6.ID, AllSkillEntity6);
        }

       AllSkillEntity AllSkillEntity7 = new AllSkillEntity();
       AllSkillEntity7.ID = 108;
       AllSkillEntity7.SkillName = @"治疗";
       AllSkillEntity7.Info = @"可以瞬间恢复自己200血量,并使自己3米范围内最近的友军得到100血量的治疗";
       AllSkillEntity7.CoolingTime = 180f;
       AllSkillEntity7.SkillType = 0;
       AllSkillEntity7.AttackDistance = -1f;

        if (!entityDic.ContainsKey(AllSkillEntity7.ID))
        {
          entityDic.Add(AllSkillEntity7.ID, AllSkillEntity7);
        }

       AllSkillEntity AllSkillEntity8 = new AllSkillEntity();
       AllSkillEntity8.ID = 2;
       AllSkillEntity8.SkillName = @"普通物理攻击";
       AllSkillEntity8.Info = @"对英雄造成相当于自身攻击力的伤害";
       AllSkillEntity8.CoolingTime = 0.5f;
       AllSkillEntity8.SkillType = 1;
       AllSkillEntity8.AttackDistance = 4f;

        if (!entityDic.ContainsKey(AllSkillEntity8.ID))
        {
          entityDic.Add(AllSkillEntity8.ID, AllSkillEntity8);
        }

       AllSkillEntity AllSkillEntity9 = new AllSkillEntity();
       AllSkillEntity9.ID = 3;
       AllSkillEntity9.SkillName = @"普通法术攻击";
       AllSkillEntity9.Info = @"对英雄造成相当于自身法术强度的伤害";
       AllSkillEntity9.CoolingTime = 0.5f;
       AllSkillEntity9.SkillType = 1;
       AllSkillEntity9.AttackDistance = 4f;

        if (!entityDic.ContainsKey(AllSkillEntity9.ID))
        {
          entityDic.Add(AllSkillEntity9.ID, AllSkillEntity9);
        }

       AllSkillEntity AllSkillEntity10 = new AllSkillEntity();
       AllSkillEntity10.ID = 4;
       AllSkillEntity10.SkillName = @"回城";
       AllSkillEntity10.Info = @"施放技能回到出生泉水";
       AllSkillEntity10.CoolingTime = 4f;
       AllSkillEntity10.SkillType = 1;
       AllSkillEntity10.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity10.ID))
        {
          entityDic.Add(AllSkillEntity10.ID, AllSkillEntity10);
        }

       AllSkillEntity AllSkillEntity11 = new AllSkillEntity();
       AllSkillEntity11.ID = 100101;
       AllSkillEntity11.SkillName = @"火炎刃";
       AllSkillEntity11.Info = @"测试..";
       AllSkillEntity11.CoolingTime = 8f;
       AllSkillEntity11.SkillType = 1;
       AllSkillEntity11.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity11.ID))
        {
          entityDic.Add(AllSkillEntity11.ID, AllSkillEntity11);
        }

       AllSkillEntity AllSkillEntity12 = new AllSkillEntity();
       AllSkillEntity12.ID = 100102;
       AllSkillEntity12.SkillName = @"三阳真火诀";
       AllSkillEntity12.Info = @"测试..";
       AllSkillEntity12.CoolingTime = 5f;
       AllSkillEntity12.SkillType = 1;
       AllSkillEntity12.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity12.ID))
        {
          entityDic.Add(AllSkillEntity12.ID, AllSkillEntity12);
        }

       AllSkillEntity AllSkillEntity13 = new AllSkillEntity();
       AllSkillEntity13.ID = 100103;
       AllSkillEntity13.SkillName = @"五方浩风诀";
       AllSkillEntity13.Info = @"测试..";
       AllSkillEntity13.CoolingTime = 7f;
       AllSkillEntity13.SkillType = 1;
       AllSkillEntity13.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity13.ID))
        {
          entityDic.Add(AllSkillEntity13.ID, AllSkillEntity13);
        }

       AllSkillEntity AllSkillEntity14 = new AllSkillEntity();
       AllSkillEntity14.ID = 100104;
       AllSkillEntity14.SkillName = @"六合寒水诀";
       AllSkillEntity14.Info = @"测试..";
       AllSkillEntity14.CoolingTime = 30f;
       AllSkillEntity14.SkillType = 1;
       AllSkillEntity14.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity14.ID))
        {
          entityDic.Add(AllSkillEntity14.ID, AllSkillEntity14);
        }

       AllSkillEntity AllSkillEntity15 = new AllSkillEntity();
       AllSkillEntity15.ID = 100201;
       AllSkillEntity15.SkillName = @"七星聚首";
       AllSkillEntity15.Info = @"测试..";
       AllSkillEntity15.CoolingTime = 8f;
       AllSkillEntity15.SkillType = 1;
       AllSkillEntity15.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity15.ID))
        {
          entityDic.Add(AllSkillEntity15.ID, AllSkillEntity15);
        }

       AllSkillEntity AllSkillEntity16 = new AllSkillEntity();
       AllSkillEntity16.ID = 100202;
       AllSkillEntity16.SkillName = @"索神决";
       AllSkillEntity16.Info = @"测试..";
       AllSkillEntity16.CoolingTime = 5f;
       AllSkillEntity16.SkillType = 1;
       AllSkillEntity16.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity16.ID))
        {
          entityDic.Add(AllSkillEntity16.ID, AllSkillEntity16);
        }

       AllSkillEntity AllSkillEntity17 = new AllSkillEntity();
       AllSkillEntity17.ID = 100203;
       AllSkillEntity17.SkillName = @"九玄天元诀";
       AllSkillEntity17.Info = @"测试..";
       AllSkillEntity17.CoolingTime = 7f;
       AllSkillEntity17.SkillType = 1;
       AllSkillEntity17.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity17.ID))
        {
          entityDic.Add(AllSkillEntity17.ID, AllSkillEntity17);
        }

       AllSkillEntity AllSkillEntity18 = new AllSkillEntity();
       AllSkillEntity18.ID = 100204;
       AllSkillEntity18.SkillName = @"八荒地煞诀";
       AllSkillEntity18.Info = @"测试..";
       AllSkillEntity18.CoolingTime = 30f;
       AllSkillEntity18.SkillType = 1;
       AllSkillEntity18.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity18.ID))
        {
          entityDic.Add(AllSkillEntity18.ID, AllSkillEntity18);
        }

       AllSkillEntity AllSkillEntity19 = new AllSkillEntity();
       AllSkillEntity19.ID = 100301;
       AllSkillEntity19.SkillName = @"焚心术";
       AllSkillEntity19.Info = @"测试..";
       AllSkillEntity19.CoolingTime = 8f;
       AllSkillEntity19.SkillType = 1;
       AllSkillEntity19.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity19.ID))
        {
          entityDic.Add(AllSkillEntity19.ID, AllSkillEntity19);
        }

       AllSkillEntity AllSkillEntity20 = new AllSkillEntity();
       AllSkillEntity20.ID = 100302;
       AllSkillEntity20.SkillName = @"百鬼夜行";
       AllSkillEntity20.Info = @"测试..";
       AllSkillEntity20.CoolingTime = 5f;
       AllSkillEntity20.SkillType = 1;
       AllSkillEntity20.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity20.ID))
        {
          entityDic.Add(AllSkillEntity20.ID, AllSkillEntity20);
        }

       AllSkillEntity AllSkillEntity21 = new AllSkillEntity();
       AllSkillEntity21.ID = 100303;
       AllSkillEntity21.SkillName = @"阴阳符";
       AllSkillEntity21.Info = @"测试..";
       AllSkillEntity21.CoolingTime = 7f;
       AllSkillEntity21.SkillType = 1;
       AllSkillEntity21.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity21.ID))
        {
          entityDic.Add(AllSkillEntity21.ID, AllSkillEntity21);
        }

       AllSkillEntity AllSkillEntity22 = new AllSkillEntity();
       AllSkillEntity22.ID = 100304;
       AllSkillEntity22.SkillName = @"脱胎换骨";
       AllSkillEntity22.Info = @"测试..";
       AllSkillEntity22.CoolingTime = 30f;
       AllSkillEntity22.SkillType = 1;
       AllSkillEntity22.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity22.ID))
        {
          entityDic.Add(AllSkillEntity22.ID, AllSkillEntity22);
        }

       AllSkillEntity AllSkillEntity23 = new AllSkillEntity();
       AllSkillEntity23.ID = 100401;
       AllSkillEntity23.SkillName = @"破天击";
       AllSkillEntity23.Info = @"测试..";
       AllSkillEntity23.CoolingTime = 8f;
       AllSkillEntity23.SkillType = 1;
       AllSkillEntity23.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity23.ID))
        {
          entityDic.Add(AllSkillEntity23.ID, AllSkillEntity23);
        }

       AllSkillEntity AllSkillEntity24 = new AllSkillEntity();
       AllSkillEntity24.ID = 100402;
       AllSkillEntity24.SkillName = @"金戈吟";
       AllSkillEntity24.Info = @"测试..";
       AllSkillEntity24.CoolingTime = 5f;
       AllSkillEntity24.SkillType = 1;
       AllSkillEntity24.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity24.ID))
        {
          entityDic.Add(AllSkillEntity24.ID, AllSkillEntity24);
        }

       AllSkillEntity AllSkillEntity25 = new AllSkillEntity();
       AllSkillEntity25.ID = 100403;
       AllSkillEntity25.SkillName = @"惊魂击";
       AllSkillEntity25.Info = @"测试..";
       AllSkillEntity25.CoolingTime = 7f;
       AllSkillEntity25.SkillType = 1;
       AllSkillEntity25.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity25.ID))
        {
          entityDic.Add(AllSkillEntity25.ID, AllSkillEntity25);
        }

       AllSkillEntity AllSkillEntity26 = new AllSkillEntity();
       AllSkillEntity26.ID = 100404;
       AllSkillEntity26.SkillName = @"天地震";
       AllSkillEntity26.Info = @"测试..";
       AllSkillEntity26.CoolingTime = 30f;
       AllSkillEntity26.SkillType = 1;
       AllSkillEntity26.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity26.ID))
        {
          entityDic.Add(AllSkillEntity26.ID, AllSkillEntity26);
        }

       AllSkillEntity AllSkillEntity27 = new AllSkillEntity();
       AllSkillEntity27.ID = 100501;
       AllSkillEntity27.SkillName = @"烁空劲";
       AllSkillEntity27.Info = @"测试..";
       AllSkillEntity27.CoolingTime = 8f;
       AllSkillEntity27.SkillType = 1;
       AllSkillEntity27.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity27.ID))
        {
          entityDic.Add(AllSkillEntity27.ID, AllSkillEntity27);
        }

       AllSkillEntity AllSkillEntity28 = new AllSkillEntity();
       AllSkillEntity28.ID = 100502;
       AllSkillEntity28.SkillName = @"镇龙击";
       AllSkillEntity28.Info = @"测试..";
       AllSkillEntity28.CoolingTime = 5f;
       AllSkillEntity28.SkillType = 1;
       AllSkillEntity28.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity28.ID))
        {
          entityDic.Add(AllSkillEntity28.ID, AllSkillEntity28);
        }

       AllSkillEntity AllSkillEntity29 = new AllSkillEntity();
       AllSkillEntity29.ID = 100503;
       AllSkillEntity29.SkillName = @"沧澜破";
       AllSkillEntity29.Info = @"测试..";
       AllSkillEntity29.CoolingTime = 7f;
       AllSkillEntity29.SkillType = 1;
       AllSkillEntity29.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity29.ID))
        {
          entityDic.Add(AllSkillEntity29.ID, AllSkillEntity29);
        }

       AllSkillEntity AllSkillEntity30 = new AllSkillEntity();
       AllSkillEntity30.ID = 100504;
       AllSkillEntity30.SkillName = @"赤乌坠";
       AllSkillEntity30.Info = @"测试..";
       AllSkillEntity30.CoolingTime = 30f;
       AllSkillEntity30.SkillType = 1;
       AllSkillEntity30.AttackDistance = 0f;

        if (!entityDic.ContainsKey(AllSkillEntity30.ID))
        {
          entityDic.Add(AllSkillEntity30.ID, AllSkillEntity30);
        }

    }

    
    static Dictionary<int, AllSkillEntity> entityDic = new Dictionary<int, AllSkillEntity>();
    public static AllSkillEntity Get(int key)
    {
        if (entityDic.ContainsKey(key))
        {
            return entityDic[key];
        }
        return null;
    }

    
   
    public static AllSkillEntity GetInstance(int key)
    {
        AllSkillEntity instance = new AllSkillEntity();
        if (entityDic.ContainsKey(key))
        {
            
            instance.ID = entityDic[key].ID;
            instance.SkillName = entityDic[key].SkillName;
            instance.Info = entityDic[key].Info;
            instance.CoolingTime = entityDic[key].CoolingTime;
            instance.SkillType = entityDic[key].SkillType;
            instance.AttackDistance = entityDic[key].AttackDistance;

        }
        return instance;
    }
}


public class AllSkillEntity
{
    //TemplateMember
    public int ID;//技能ID
    public string SkillName;//名称
    public string Info;//介绍
    public float CoolingTime;//冷却时长
    public int SkillType;//技能类型:0瞬发,没有动画 1:带动画,由关键帧触发
    public float AttackDistance;//攻击距离(米/半径)

}
