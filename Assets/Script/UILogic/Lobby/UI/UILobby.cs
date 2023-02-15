using Game.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILobby : UIBase
{
    public UILobby()
    {
        selfType = UIType.Lobby;
        scenesType = ScenesType.Logic;
        resName = "UIPrefab/Lobby/UILobby";
    }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
    }

    protected override void Awake()
    {
        base.Awake();
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
    }
}
