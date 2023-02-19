using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class PlayerCtrl : MonoBehaviour
{
    Vector3 spawnPosition;
    Vector3 spawnRotation;
    readonly Vector3 cameraOffset = new Vector3(0, 11, 10);
    public PlayerInfo playerInfo;
    private bool isSelf;
    HeroAttributeEntity currentAttribute;
    HeroAttributeEntity totalAttribute;
    GameObject hud;
    Vector3 hudOffset = new Vector3(0, 3.1f, 0);
    Text HPText;
    Text MPText;
    Text levelText;
    Text nickNameText;
    Image HPFill;
    Image MPFill;
    SkillMgr skillMgr;
    AnimatorMgr animatorMgr;
    public PlayerFSM playerFSM;

    public void Init(PlayerInfo playerInfo)
    {
        
        this.playerInfo = playerInfo;
        isSelf = PlayerMgr.Instance.CheckIsSelfRoles(playerInfo.RolesInfo.RolesID);
        spawnPosition = transform.position;
        spawnRotation = transform.eulerAngles;

        currentAttribute = HeroAttributeConfig.GetInstance(playerInfo.HeroID);
        totalAttribute = HeroAttributeConfig.GetInstance(playerInfo.HeroID);

        RoomMgr.Instance.SaveHeroAttribute(playerInfo.RolesInfo.RolesID, currentAttribute, totalAttribute);
        //人物的HUD 血条 蓝条 昵称
        hud = ResMgr.Instance.LoadModel("HUD/heroHead");
        hud.transform.position = transform.position + hudOffset;
        hud.transform.eulerAngles = Camera.main.transform.eulerAngles;
        HPFill = hud.transform.Find("HP/Fill").GetComponent<Image>();
        MPFill = hud.transform.Find("MP/Fill").GetComponent<Image>();
        HPText = hud.transform.Find("HP/Text").GetComponent<Text>();
        MPText = hud.transform.Find("MP/Text").GetComponent<Text>();
        nickNameText = hud.transform.Find("NickName").GetComponent<Text>();
        levelText = hud.transform.Find("Level/Text").GetComponent<Text>();
        //技能管理器
        skillMgr = this.gameObject.AddComponent<SkillMgr>();
        skillMgr.Init(this);
        //动画管理器
        animatorMgr = this.gameObject.AddComponent<AnimatorMgr>();
        animatorMgr.Init(this);
        //角色状态机
        playerFSM = this.gameObject.AddComponent<PlayerFSM>();
        playerFSM.Init(this);

        if (isSelf)
        {
            if (playerInfo.TeamID==0)
            {
                Camera.main.transform.eulerAngles = new Vector3(45, 180, 0);
            }
            else
            {
                Camera.main.transform.eulerAngles = new Vector3(45, -180, 0);
            }
        }
    }

    void HUDUpdate(bool init = false)
    {
        HPText.text = $"{currentAttribute.HP}/{totalAttribute.HP}";
        MPText.text = $"{currentAttribute.MP}/{totalAttribute.MP}";
        levelText.text = currentAttribute.Level.ToString();
        nickNameText.text = playerInfo.RolesInfo.NickName;

        if (init)
        {
            HPFill.fillAmount = 1;
            MPFill.fillAmount = 1;
        }
        else
        {
            HPFill.DOFillAmount(currentAttribute.HP / totalAttribute.HP, 0.2f).SetAutoKill(true);
            MPFill.DOFillAmount(currentAttribute.MP / totalAttribute.MP, 0.2f).SetAutoKill(true);
        }
    }

    void LateUpdate()
    {
        if (hud != null)
        {
            hud.transform.position = transform.position + hudOffset;
        }

        if (isSelf)
        {
            Camera.main.transform.position = this.transform.position + cameraOffset;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
