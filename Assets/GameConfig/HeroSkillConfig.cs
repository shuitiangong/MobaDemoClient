
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class HeroSkillConfig
{

    static HeroSkillConfig()
    {
        
       HeroSkillEntity HeroSkillEntity0 = new HeroSkillEntity();
       HeroSkillEntity0.ID = 1001;
       HeroSkillEntity0.A_ID = 3;
       HeroSkillEntity0.Q_ID = 100101;
       HeroSkillEntity0.W_ID = 100102;
       HeroSkillEntity0.E_ID = 100103;
       HeroSkillEntity0.R_ID = 100104;

        if (!entityDic.ContainsKey(HeroSkillEntity0.ID))
        {
          entityDic.Add(HeroSkillEntity0.ID, HeroSkillEntity0);
        }

       HeroSkillEntity HeroSkillEntity1 = new HeroSkillEntity();
       HeroSkillEntity1.ID = 1002;
       HeroSkillEntity1.A_ID = 3;
       HeroSkillEntity1.Q_ID = 100201;
       HeroSkillEntity1.W_ID = 100202;
       HeroSkillEntity1.E_ID = 100203;
       HeroSkillEntity1.R_ID = 100204;

        if (!entityDic.ContainsKey(HeroSkillEntity1.ID))
        {
          entityDic.Add(HeroSkillEntity1.ID, HeroSkillEntity1);
        }

       HeroSkillEntity HeroSkillEntity2 = new HeroSkillEntity();
       HeroSkillEntity2.ID = 1003;
       HeroSkillEntity2.A_ID = 3;
       HeroSkillEntity2.Q_ID = 100301;
       HeroSkillEntity2.W_ID = 100302;
       HeroSkillEntity2.E_ID = 100303;
       HeroSkillEntity2.R_ID = 100304;

        if (!entityDic.ContainsKey(HeroSkillEntity2.ID))
        {
          entityDic.Add(HeroSkillEntity2.ID, HeroSkillEntity2);
        }

       HeroSkillEntity HeroSkillEntity3 = new HeroSkillEntity();
       HeroSkillEntity3.ID = 1004;
       HeroSkillEntity3.A_ID = 3;
       HeroSkillEntity3.Q_ID = 100401;
       HeroSkillEntity3.W_ID = 100402;
       HeroSkillEntity3.E_ID = 100403;
       HeroSkillEntity3.R_ID = 100404;

        if (!entityDic.ContainsKey(HeroSkillEntity3.ID))
        {
          entityDic.Add(HeroSkillEntity3.ID, HeroSkillEntity3);
        }

       HeroSkillEntity HeroSkillEntity4 = new HeroSkillEntity();
       HeroSkillEntity4.ID = 1005;
       HeroSkillEntity4.A_ID = 3;
       HeroSkillEntity4.Q_ID = 100501;
       HeroSkillEntity4.W_ID = 100502;
       HeroSkillEntity4.E_ID = 100503;
       HeroSkillEntity4.R_ID = 100504;

        if (!entityDic.ContainsKey(HeroSkillEntity4.ID))
        {
          entityDic.Add(HeroSkillEntity4.ID, HeroSkillEntity4);
        }

    }

    
    static Dictionary<int, HeroSkillEntity> entityDic = new Dictionary<int, HeroSkillEntity>();
    public static HeroSkillEntity Get(int key)
    {
        if (entityDic.ContainsKey(key))
        {
            return entityDic[key];
        }
        return null;
    }

    
   
    public static HeroSkillEntity GetInstance(int key)
    {
        HeroSkillEntity instance = new HeroSkillEntity();
        if (entityDic.ContainsKey(key))
        {
            
            instance.ID = entityDic[key].ID;
            instance.A_ID = entityDic[key].A_ID;
            instance.Q_ID = entityDic[key].Q_ID;
            instance.W_ID = entityDic[key].W_ID;
            instance.E_ID = entityDic[key].E_ID;
            instance.R_ID = entityDic[key].R_ID;

        }
        return instance;
    }
}


public class HeroSkillEntity
{
    //TemplateMember
    public int ID;//英雄ID
    public int A_ID;//A的ID
    public int Q_ID;//Q的ID
    public int W_ID;//W的ID
    public int E_ID;//E的ID
    public int R_ID;//R的ID

}
