using Game.Net;
using Game.View;
using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UILogin : BaseWindow
{
    private InputField AccountInput;
    private InputField PwdInput;
    public UILogin()
    {
        scenesType = ScenesType.Login;
        resident = false;
        resName = "UIPrefab/User/UILogin";
    }
    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
    }

    protected override void Awake()
    {
        base.Awake();
        AccountInput = transform.Find("UserBack/AccountInput").GetComponent<InputField>();
        PwdInput = transform.Find("UserBack/PwdInput").GetComponent<InputField>();
    }

    protected override void OnAddListener()
    {
        base.OnAddListener();
        NetEvent.Instance.AddEventListener(1000, ResUserRegister);
        NetEvent.Instance.AddEventListener(1001, ResUserLogin);
    }

    private void ResUserRegister(BufferEntity p)
    {
        UserRegisterS2C s2cMSG = ProtobufHelper.FromBytes<UserRegisterS2C>(p.proto);
        switch (s2cMSG.Result)
        {
            case 0:
                Debug.Log("注册成功！");
                break;
            case 1:
                Debug.Log("存在敏感词！");
                break;
            case 2:
                Debug.Log("账号或密码格式错误！");
                break;
            case 3:
                Debug.Log("账号已注册！");
                break;
            default:
                break;
        }
    }

    private void ResUserLogin(BufferEntity p)
    {
        UserLoginS2C s2cMSG = ProtobufHelper.FromBytes<UserLoginS2C>(p.proto);
        switch (s2cMSG.Result)
        {
            case 0:
                Debug.Log("登陆成功！");
                //保存数据
                if (s2cMSG.RolesInfo!=null)
                {
                    //保存数据 打开大厅界面
                    LoginMgr.Instance.SaveRoleInfo(s2cMSG.RolesInfo);
                }
                else
                {
                    //跳转到角色界面
                }
                Close(); 
                break;
            case 1:
                Debug.Log("账号不存在！");
                break;
            case 2:
                Debug.Log("密码错误！");
                break;
            case 3:
                break;
            default:
                break;
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
    }

    protected override void RegisterUIEvent()
    {
        base.RegisterUIEvent();
        for (int i = 0; i < buttonList.Length; i++)
        {
            switch(buttonList[i].name)
            {
                case "RegisterBtn":
                    buttonList[i].onClick.AddListener(OnClickRegister);
                    break;
                case "LoginBtn":
                    buttonList[i].onClick.AddListener(OnClickLoginBtn);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnClickRegister()
    {
        if (string.IsNullOrEmpty(AccountInput.text))
        {
            Debug.Log("账号为空...");
            return;
        }
        if (string.IsNullOrEmpty(AccountInput.text))
        {
            Debug.Log("密码为空...");
            return;
        }
        UserRegisterC2S c2sMSG = new UserRegisterC2S();
        c2sMSG.UserInfo = new UserInfo();
        c2sMSG.UserInfo.Account = AccountInput.text;
        c2sMSG.UserInfo.Password = PwdInput.text;
        BufferFactory.CreateAndSendPackage(1000, c2sMSG);
    }

    private void OnClickLoginBtn()
    {
        if (string.IsNullOrEmpty(AccountInput.text))
        {
            Debug.Log("账号为空...");
            return;
        }
        if (string.IsNullOrEmpty(AccountInput.text))
        {
            Debug.Log("密码为空...");
            return;
        }
        UserLoginC2S c2sMSG = new UserLoginC2S();
        c2sMSG.UserInfo = new UserInfo();
        c2sMSG.UserInfo.Account = AccountInput.text;
        c2sMSG.UserInfo.Password = PwdInput.text;
        BufferFactory.CreateAndSendPackage(1001, c2sMSG);
    }


}
