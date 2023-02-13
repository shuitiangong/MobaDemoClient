﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.View;
/// <summary>
/// 窗体类型
/// </summary>
public enum WindowType
{
    LoginWindow,
    RolesWindow,
    LobbyWindow,
    RoomWindow,
    BattleWindow,
    TipsWindow,
}

/// <summary>
/// 场景类型,目的:提供根据场景类型进行预加载
/// </summary>
public enum ScenesType
{
    None,
    Login,
    Battle,
}


public class WindowManager : MonoSingleton<WindowManager>
{
    Dictionary<WindowType, BaseWindow> windowDIC = new Dictionary<WindowType, BaseWindow>();
    //构造函数 初始化
    public WindowManager() {
        windowDIC.Add(WindowType.LoginWindow, new UILogin());
        //商店
        //
        //windowDIC.Add(WindowType.StoreWindow,new StoreWindow());
    }

    public void Update()
    {
        foreach (var window in windowDIC.Values)
        {
            if (window.IsVisible())
            {
                window.Update(Time.deltaTime);
            }
        }
            
    }
    //打开窗口
    public BaseWindow OpenWindow(WindowType type) {
        BaseWindow window;
        if (windowDIC.TryGetValue(type, out window))
        {
            window.Open();
            return window;
        }
        else
        {
            Debug.LogError($"Open Error:{type}");
            return null;
        }
    }

    //关闭窗口
    public void CloseWindow(WindowType type) {
        BaseWindow window;
        if (windowDIC.TryGetValue(type, out window))
        {
            window.Close();
        }
        else
        {
            Debug.LogError($"Open Error:{type}");
        }
    }

    //预加载
    public void PreLoadWindow(ScenesType type)
    {
        foreach (var item in windowDIC.Values)
        {
            if (item.GetScenesType()==type)
            {
                item.PreLoad();
            }
        }
    }

    //隐藏掉某个类型的所有窗口
    public void HideAllWindow(ScenesType type,bool isDestroy=false) {

        foreach (var item in windowDIC.Values)
        {
            if (item.GetScenesType() == type)
            {
                item.Close(isDestroy);
            }
        }
    }
}
