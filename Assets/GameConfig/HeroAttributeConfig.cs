
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class HeroAttributeConfig
{

    static HeroAttributeConfig()
    {
        
       HeroAttributeEntity HeroAttributeEntity0 = new HeroAttributeEntity();
       HeroAttributeEntity0.ID = 1001;
       HeroAttributeEntity0.HeroName = @"摩妙";
       HeroAttributeEntity0.Occupation = @"法师";
       HeroAttributeEntity0.Level = 1;
       HeroAttributeEntity0.HP = 800f;
       HeroAttributeEntity0.MP = 500f;
       HeroAttributeEntity0.Power = 1f;
       HeroAttributeEntity0.Spells = 30f;
       HeroAttributeEntity0.Armor = 10f;
       HeroAttributeEntity0.MagicResistance = 10f;
       HeroAttributeEntity0.ArmorBreaking = 0f;
       HeroAttributeEntity0.PierceThrough = 0f;
       HeroAttributeEntity0.Crit = 0f;
       HeroAttributeEntity0.MoveSpeed = 300f;
       HeroAttributeEntity0.AttackSpeed = 1f;
       HeroAttributeEntity0.CoolingShrinkage = 0f;

        if (!entityDic.ContainsKey(HeroAttributeEntity0.ID))
        {
          entityDic.Add(HeroAttributeEntity0.ID, HeroAttributeEntity0);
        }

       HeroAttributeEntity HeroAttributeEntity1 = new HeroAttributeEntity();
       HeroAttributeEntity1.ID = 1002;
       HeroAttributeEntity1.HeroName = @"梵音";
       HeroAttributeEntity1.Occupation = @"法师";
       HeroAttributeEntity1.Level = 1;
       HeroAttributeEntity1.HP = 600f;
       HeroAttributeEntity1.MP = 500f;
       HeroAttributeEntity1.Power = 1f;
       HeroAttributeEntity1.Spells = 50f;
       HeroAttributeEntity1.Armor = 10f;
       HeroAttributeEntity1.MagicResistance = 10f;
       HeroAttributeEntity1.ArmorBreaking = 0f;
       HeroAttributeEntity1.PierceThrough = 0f;
       HeroAttributeEntity1.Crit = 0f;
       HeroAttributeEntity1.MoveSpeed = 300f;
       HeroAttributeEntity1.AttackSpeed = 1f;
       HeroAttributeEntity1.CoolingShrinkage = 0f;

        if (!entityDic.ContainsKey(HeroAttributeEntity1.ID))
        {
          entityDic.Add(HeroAttributeEntity1.ID, HeroAttributeEntity1);
        }

       HeroAttributeEntity HeroAttributeEntity2 = new HeroAttributeEntity();
       HeroAttributeEntity2.ID = 1003;
       HeroAttributeEntity2.HeroName = @"师子";
       HeroAttributeEntity2.Occupation = @"法师";
       HeroAttributeEntity2.Level = 1;
       HeroAttributeEntity2.HP = 700f;
       HeroAttributeEntity2.MP = 500f;
       HeroAttributeEntity2.Power = 1f;
       HeroAttributeEntity2.Spells = 40f;
       HeroAttributeEntity2.Armor = 10f;
       HeroAttributeEntity2.MagicResistance = 10f;
       HeroAttributeEntity2.ArmorBreaking = 0f;
       HeroAttributeEntity2.PierceThrough = 0f;
       HeroAttributeEntity2.Crit = 0f;
       HeroAttributeEntity2.MoveSpeed = 300f;
       HeroAttributeEntity2.AttackSpeed = 1f;
       HeroAttributeEntity2.CoolingShrinkage = 0f;

        if (!entityDic.ContainsKey(HeroAttributeEntity2.ID))
        {
          entityDic.Add(HeroAttributeEntity2.ID, HeroAttributeEntity2);
        }

       HeroAttributeEntity HeroAttributeEntity3 = new HeroAttributeEntity();
       HeroAttributeEntity3.ID = 1004;
       HeroAttributeEntity3.HeroName = @"广持";
       HeroAttributeEntity3.Occupation = @"法师";
       HeroAttributeEntity3.Level = 1;
       HeroAttributeEntity3.HP = 850f;
       HeroAttributeEntity3.MP = 500f;
       HeroAttributeEntity3.Power = 1f;
       HeroAttributeEntity3.Spells = 60f;
       HeroAttributeEntity3.Armor = 10f;
       HeroAttributeEntity3.MagicResistance = 10f;
       HeroAttributeEntity3.ArmorBreaking = 0f;
       HeroAttributeEntity3.PierceThrough = 0f;
       HeroAttributeEntity3.Crit = 0f;
       HeroAttributeEntity3.MoveSpeed = 300f;
       HeroAttributeEntity3.AttackSpeed = 1f;
       HeroAttributeEntity3.CoolingShrinkage = 0f;

        if (!entityDic.ContainsKey(HeroAttributeEntity3.ID))
        {
          entityDic.Add(HeroAttributeEntity3.ID, HeroAttributeEntity3);
        }

       HeroAttributeEntity HeroAttributeEntity4 = new HeroAttributeEntity();
       HeroAttributeEntity4.ID = 1005;
       HeroAttributeEntity4.HeroName = @"张武";
       HeroAttributeEntity4.Occupation = @"法师";
       HeroAttributeEntity4.Level = 1;
       HeroAttributeEntity4.HP = 750f;
       HeroAttributeEntity4.MP = 500f;
       HeroAttributeEntity4.Power = 1f;
       HeroAttributeEntity4.Spells = 55f;
       HeroAttributeEntity4.Armor = 10f;
       HeroAttributeEntity4.MagicResistance = 10f;
       HeroAttributeEntity4.ArmorBreaking = 0f;
       HeroAttributeEntity4.PierceThrough = 0f;
       HeroAttributeEntity4.Crit = 0f;
       HeroAttributeEntity4.MoveSpeed = 300f;
       HeroAttributeEntity4.AttackSpeed = 1f;
       HeroAttributeEntity4.CoolingShrinkage = 0f;

        if (!entityDic.ContainsKey(HeroAttributeEntity4.ID))
        {
          entityDic.Add(HeroAttributeEntity4.ID, HeroAttributeEntity4);
        }

    }

    
    static Dictionary<int, HeroAttributeEntity> entityDic = new Dictionary<int, HeroAttributeEntity>();
    public static HeroAttributeEntity Get(int key)
    {
        if (entityDic.ContainsKey(key))
        {
            return entityDic[key];
        }
        return null;
    }

    
   
    public static HeroAttributeEntity GetInstance(int key)
    {
        HeroAttributeEntity instance = new HeroAttributeEntity();
        if (entityDic.ContainsKey(key))
        {
            
            instance.ID = entityDic[key].ID;
            instance.HeroName = entityDic[key].HeroName;
            instance.Occupation = entityDic[key].Occupation;
            instance.Level = entityDic[key].Level;
            instance.HP = entityDic[key].HP;
            instance.MP = entityDic[key].MP;
            instance.Power = entityDic[key].Power;
            instance.Spells = entityDic[key].Spells;
            instance.Armor = entityDic[key].Armor;
            instance.MagicResistance = entityDic[key].MagicResistance;
            instance.ArmorBreaking = entityDic[key].ArmorBreaking;
            instance.PierceThrough = entityDic[key].PierceThrough;
            instance.Crit = entityDic[key].Crit;
            instance.MoveSpeed = entityDic[key].MoveSpeed;
            instance.AttackSpeed = entityDic[key].AttackSpeed;
            instance.CoolingShrinkage = entityDic[key].CoolingShrinkage;

        }
        return instance;
    }
}


public class HeroAttributeEntity
{
    //TemplateMember
    public int ID;//英雄ID
    public string HeroName;//英雄名称
    public string Occupation;//职业名称
    public int Level;//初始等级
    public float HP;//生命
    public float MP;//魔法值
    public float Power;//力量
    public float Spells;//法强
    public float Armor;//护甲
    public float MagicResistance;//魔抗
    public float ArmorBreaking;//破甲
    public float PierceThrough;//穿透
    public float Crit;//暴击
    public float MoveSpeed;//移速
    public float AttackSpeed;//攻速
    public float CoolingShrinkage;//冷却收缩

}
