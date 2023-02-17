using Game.Net;
using Game.View;
using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRoles : UIBase
{
    InputField inputField;
    public UIRoles()
    {
        selfType = UIType.Login;
        scenesType = ScenesType.Login;
        resident = false;
        resName = "Roles/UIRoles";
    }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
    }

    protected override void Awake()
    {
        base.Awake();
        inputField = transform.Find("RolesBG/InputField").GetComponent<InputField>();
    }

    protected override void OnAddListener()
    {
        base.OnAddListener();
        NetEvent.Instance.AddEventListener(1201, ResRolesCreateS2C);
    }

    private void ResRolesCreateS2C(BufferEntity res)
    {
        RolesCreateS2C s2cMSG = ProtobufHelper.FromBytes<RolesCreateS2C>(res.proto);
        if (s2cMSG.Result==0)
        {
            //缓存角色
            RolesMgr.Instance.SaveRolesInfo(s2cMSG.RolesInfo);
            Close();
            UIMgr.Instance.ShowUI(UIType.Lobby);
        }
        else
        {
            UIMgr.Instance.ShowTips("角色已存在，创建失败");
        }

    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnRemoveListener()
    {
        base.OnRemoveListener();
        NetEvent.Instance.RemoveEventListener(1201, ResRolesCreateS2C);
    }

    protected override void RegisterUIEvent()
    {
        base.RegisterUIEvent();
        for (int i = 0; i<buttonList.Length; i++)
        {
            switch(buttonList[i].name)
            {
                case "StartBtn":
                    buttonList[i].onClick.AddListener(OnClickStartBtn);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnClickStartBtn()
    {
        RolesCreateC2S c2sMSG = new RolesCreateC2S();
        c2sMSG.NickName = inputField.text;
        BufferFactory.CreateAndSendPackage(1201, c2sMSG);
    }
}
