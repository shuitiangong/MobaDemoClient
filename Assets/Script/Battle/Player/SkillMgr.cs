using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMgr : MonoBehaviour
{
    PlayerCtrl playerCtrl;
    PlayerInfo playerInfo;
    Dictionary<KeyCode, int> skillID;
    Dictionary<KeyCode, float> coolingConfig;
    Dictionary<KeyCode, float> keyDownTime;
    public void Init(PlayerCtrl playerCtrl)
    {
        skillID = new Dictionary<KeyCode, int>();
        coolingConfig = new Dictionary<KeyCode, float>();
        keyDownTime = new Dictionary<KeyCode, float>();

        this.playerCtrl = playerCtrl;
        playerInfo = playerCtrl.playerInfo;

        //技能的配置信息
        HeroSkillEntity skill = HeroSkillConfig.GetInstance(playerInfo.HeroID);
        skillID[KeyCode.Q] = skill.Q_ID;
        skillID[KeyCode.W] = skill.W_ID;
        skillID[KeyCode.E] = skill.E_ID;
        skillID[KeyCode.R] = skill.R_ID;
        skillID[KeyCode.A] = skill.A_ID;
        skillID[KeyCode.D] = playerInfo.SkillA;
        skillID[KeyCode.F] = playerInfo.SkillB;
        skillID[KeyCode.B] = 4;

        coolingConfig[KeyCode.Q] = AllSkillConfig.Get(skill.Q_ID).CoolingTime;
        coolingConfig[KeyCode.W] = AllSkillConfig.Get(skill.W_ID).CoolingTime;
        coolingConfig[KeyCode.E] = AllSkillConfig.Get(skill.E_ID).CoolingTime;
        coolingConfig[KeyCode.R] = AllSkillConfig.Get(skill.R_ID).CoolingTime;
        coolingConfig[KeyCode.A] = 0.5f;
        coolingConfig[KeyCode.D] = 180;
        coolingConfig[KeyCode.F] = 180;
        coolingConfig[KeyCode.B] = 4; //回城的时间

    }

    public void DeCooling(KeyCode key, Action<float> action)
    {
        keyDownTime[key] = Time.time;
        if (action!=null)
        {
            action(keyDownTime[key]);
        }
    }

    public float SurplusTIme(KeyCode key)
    {
        //剩余的冷却时间
        float time = coolingConfig[key] - (Time.time - keyDownTime[key]);
        if (time<0)
        {
            time = 0;
        }
        return time;
    }

    public bool IsCooling(KeyCode key)
    {
        return SurplusTIme(key) > 0;
    }
    public int GetID(KeyCode key)
    {
        return skillID[key];
    }
}
