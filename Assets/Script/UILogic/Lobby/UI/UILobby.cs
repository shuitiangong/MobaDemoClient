using Game.Net;
using Game.View;
using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILobby : UIBase
{
    Transform matchModeBtn;
    Transform qualifyingBtn;
    Transform stopMatchBtn;
    Text roleName, rank, goldCount, diamondsCount, matchTips;
    public UILobby()
    {
        selfType = UIType.Lobby;
        scenesType = ScenesType.Logic;
        resident = false;
        resName = "Lobby/UILobby";
    }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
    }

    protected override void Awake()
    {
        base.Awake();
        roleName = transform.Find("LobbyBG/RolesName").GetComponent<Text>();
        rank = transform.Find("LobbyBG/Rank").GetComponent<Text>();
        goldCount = transform.Find("LobbyBG/GoldCount").GetComponent<Text>();
        diamondsCount = transform.Find("LobbyBG/DiamondsCount").GetComponent<Text>();
        matchTips = transform.Find("LobbyBG/MatchTips").GetComponent<Text>();

        matchModeBtn = transform.Find("LobbyBG/MatchModeBtn");
        qualifyingBtn = transform.Find("LobbyBG/QualifyingBtn");
        stopMatchBtn = transform.Find("Lobby/StopMatchBtn");
    }

    protected override void OnAddListener()
    {
        base.OnAddListener();
        NetEvent.Instance.AddEventListener(1300, OnLobbyToMatchS2C);
        NetEvent.Instance.AddEventListener(1301, OnLobbyUpdateMatchStateS2C);
        NetEvent.Instance.AddEventListener(1302, OnLobbyQuitMatchS2C);
    }

    private void OnLobbyToMatchS2C(BufferEntity res)
    {
        LobbyToMatchS2C s2cMSG = ProtobufHelper.FromBytes<LobbyToMatchS2C>(res.proto);
        if (s2cMSG.Result==0)
        {
            matchModeBtn.gameObject.SetActive(false);
            qualifyingBtn.gameObject.SetActive(false);
            stopMatchBtn.gameObject.SetActive(true);
            matchTips.gameObject.SetActive(true);

            //房间信息
            //RoomMgr

        }
        else
        {
            //无法进行匹配 可能被惩罚 需要等待
        }
    }

    private void OnLobbyUpdateMatchStateS2C(BufferEntity res)
    {
        LobbyUpdateMatchStateS2C s2cMSG = ProtobufHelper.FromBytes<LobbyUpdateMatchStateS2C>(res.proto);
        if (s2cMSG.Result==0)
        {
            RoomMgr.Instance.SaveRoomInfo(s2cMSG.RoomInfo);
            UIMgr.Instance.ShowUI(UIType.Room);
            Close();

        }
        else
        {

        }
    }

    private void OnLobbyQuitMatchS2C(BufferEntity res)
    {
        LobbyQuitMatchS2C s2cMSG = ProtobufHelper.FromBytes<LobbyQuitMatchS2C>(res.proto);
        if (s2cMSG.Result==0)
        {
            matchModeBtn.gameObject.SetActive(true);
            qualifyingBtn.gameObject.SetActive(true);
            stopMatchBtn.gameObject.SetActive(false);
            matchTips.gameObject.SetActive(false);
        }
        else
        {

        }
    }

    protected override void OnDisable()
    {
        base.OnDisable();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        matchModeBtn.gameObject.SetActive(true);
        qualifyingBtn.gameObject.SetActive(true);
        stopMatchBtn.gameObject.SetActive(false);
        matchTips.gameObject.SetActive(false);
        //获取到角色信息
        RolesInfo rolesInfo = PlayerMgr.Instance.GetRolesInfo();
        roleName.text = rolesInfo.NickName;
        rank.text = rolesInfo.VictoryPoint.ToString();
        goldCount.text = rolesInfo.GoldCoin.ToString();
        diamondsCount.text = rolesInfo.Diamonds.ToString();
    }

    protected override void OnRemoveListener()
    {
        base.OnRemoveListener();
        NetEvent.Instance.RemoveEventListener(1300, OnLobbyToMatchS2C);
        NetEvent.Instance.RemoveEventListener(1301, OnLobbyUpdateMatchStateS2C);
        NetEvent.Instance.RemoveEventListener(1302, OnLobbyQuitMatchS2C);
    }

    protected override void RegisterUIEvent()
    {
        base.RegisterUIEvent();
        for (int i = 0; i<buttonList.Length; i++)
        {
            switch(buttonList[i].name)
            {
                case "MatchModeBtn":
                    OnClickMatchModeBtn();
                    break;
                case "StopMatchBtn":
                    OnClickStopMatchBtn();
                    break;
                default:
                    break;
            }
        }
    }

    private void OnClickMatchModeBtn()
    {
        BufferFactory.CreateAndSendPackage(1300, null);
    }

    private void OnClickStopMatchBtn()
    {
        BufferFactory.CreateAndSendPackage(1302, null);
    }
}
