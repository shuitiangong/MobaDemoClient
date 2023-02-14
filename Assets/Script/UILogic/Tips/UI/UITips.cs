using Game.View;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITips: BaseWindow
{
    private Transform tips01;
    private Text tips01Text;
    private Action CloseBtnAction;
    private Action EnterBtnAction;

    public UITips()
    {
        scenesType = ScenesType.Logic;
        resident = false;
        resName = "UIPrefab/Tips/TipsWindow";
        selfType = WindowType.TipsWindow;
    }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
    }

    protected override void Awake()
    {
        base.Awake();
        tips01 = transform.Find("Tips01");
        tips01Text = transform.Find("Tips01/Tips01Text").GetComponent<Text>();
    }

    protected override void OnAddListener()
    {
        base.OnAddListener();
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
        for (int i = 0; i<buttonList.Length; i++)
        {
            switch(buttonList[i].name)
            {
                case "EnterBtn":
                    buttonList[i].onClick.AddListener(OnClickEnterBtn);
                    break;
                case "CloseBtn":
                    buttonList[i].onClick.AddListener(OnClickCloseBtn);
                    break;
                default:
                    break;
            }
        }
    }

    private void OnClickEnterBtn()
    {
        if (EnterBtnAction!=null)
        {
            EnterBtnAction();
            EnterBtnAction = null;
        }
        else
        {
            Close();
        }
    }

    private void OnClickCloseBtn()
    {
        if (CloseBtnAction!=null)
        {
            CloseBtnAction();
            CloseBtnAction = null;
        }
        else
        {
            Close();
        }
    }

    public void Show(string text, Action enterBtnAction, Action closeBtnAction)
    {
        tips01Text.text = text;
        EnterBtnAction = enterBtnAction;
        CloseBtnAction = closeBtnAction;
    }
}
