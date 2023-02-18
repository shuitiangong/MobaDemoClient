using Game.Net;
using Game.View;
using ProtoMsg;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIRoom : UIBase
{
    private bool isLock;
    private int lockHeroID;
    private int gridID;
    private int skillID;
    private int nowTime;
    private Transform skillInfo; //技能选择面板
    private Text time;
    private Transform teamA;
    private Transform teamB;
    private Image skillA;
    private Image skillB;
    private Text chatText;
    private Scrollbar chatVertical; //聊天窗的滚动条
    private AsyncOperation async;
    private Dictionary<int, GameObject> rolesDIC;
    private CancellationTokenSource ct;
    private Dictionary<int, GameObject> playerLoadDic;
    private InputField chatInputField;

    public UIRoom()
    {
        selfType = UIType.Room;
        scenesType = ScenesType.Logic;
        resident = false;
        resName = "Room/UIRoom";
     
    }

    public override void Update(float deltaTime)
    {
        base.Update(deltaTime);
        if (Input.GetKeyDown(KeyCode.Return))
        {
            BufferFactory.CreateAndSendPackage(1404, new RoomSendMsgC2S()
            {
                Text = chatInputField.text
            });
        }
    }



    protected override void Awake()
    {
        base.Awake();
        BattleListener.Instance.Init();
        skillInfo = transform.Find("SkillInfo");
        time = transform.Find("Time").GetComponent<Text>();
        teamA = transform.Find("TeamA/Team_HeroA_item");
        teamB = transform.Find("TeamB/Team_HeroB_item");
        skillA = transform.Find("SkillA").GetComponent<Image>();
        skillB = transform.Find("SkillB").GetComponent<Image>();
        chatText = transform.Find("ChatBG/Scroll View/Viewport/Content/ChatText").GetComponent<Text>();
        chatVertical = transform.Find("ChatBG/Scroll View/ChatVertical").GetComponent<Scrollbar>();
        chatInputField = transform.Find("ChatInput").GetComponent<InputField>();
        nowTime = 30;
        isLock = false;
        ct = new CancellationTokenSource();
        rolesDIC = new Dictionary<int, GameObject>();
        playerLoadDic = new Dictionary<int, GameObject>();
        TimeDown();
        //房间信息
        RoomInfo roomInfo = RoomMgr.Instance.GetRoomInfo();
        for (int i = 0; i<roomInfo.TeamA.Count; i++)
        {
            GameObject go = GameObject.Instantiate(teamA.gameObject, teamA.parent, false);
            go.transform.Find("Hero_NickName").GetComponent<Text>().text = roomInfo.TeamA[i].NickName;
            go.SetActive(true);
            rolesDIC[roomInfo.TeamA[i].RolesID] = go;
        }
        for (int i = 0; i < roomInfo.TeamA.Count; i++)
        {
            GameObject go = GameObject.Instantiate(teamB.gameObject, teamB.parent, false);
            go.transform.Find("Hero_NickName").GetComponent<Text>().text = roomInfo.TeamB[i].NickName;
            go.SetActive(true);
            rolesDIC[roomInfo.TeamB[i].RolesID] = go;
        }
    }

    async void TimeDown()
    {
        while (nowTime > 0)
        {
            await Task.Delay(1000); //每隔一秒
            if (!ct.IsCancellationRequested)
            {
                nowTime--;
                time.text = $"倒计时：{time}";
            }
        }
    }

    protected override void OnAddListener()
    {
        base.OnAddListener();

        NetEvent.Instance.AddEventListener(1400, OnRoomSelectHeroS2C);
        NetEvent.Instance.AddEventListener(1401, OnRoomSelectHeroSkillS2C);
        NetEvent.Instance.AddEventListener(1403, OnRoomCloseMsgS2C);
        NetEvent.Instance.AddEventListener(1404, OnRoomSendMsgS2C);
        NetEvent.Instance.AddEventListener(1405, OnRoomLockHeroS2C);
        NetEvent.Instance.AddEventListener(1406, OnRoomLoadProgressS2C);
        NetEvent.Instance.AddEventListener(1407, OnRoomToBattleS2C);
    }

    /// <summary>
    /// 选择了英雄，更新头像
    /// </summary>
    /// <param name="res"></param>
    private void OnRoomSelectHeroS2C(BufferEntity res)
    {
        RoomSelectHeroS2C s2cMSG = ProtobufHelper.FromBytes<RoomSelectHeroS2C>(res.proto);
        rolesDIC[s2cMSG.RolesID].transform.Find("Hero_Head").GetComponent<Image>().sprite
            = ResMgr.Instance.LoadSprite($"Round/{s2cMSG.HeroID}");
        if (PlayerMgr.Instance.CheckIsSelfRoles(s2cMSG.RolesID))
        {
            lockHeroID = s2cMSG.HeroID;
        }
    }
    /// <summary>
    /// 选择召唤师技能
    /// </summary>
    /// <param name="res"></param>
    private void OnRoomSelectHeroSkillS2C(BufferEntity res)
    {
        RoomSelectHeroSkillS2C s2cMSG = ProtobufHelper.FromBytes<RoomSelectHeroSkillS2C>(res.proto);
        if (s2cMSG.GridID==0)
        {
            rolesDIC[s2cMSG.RolesID].transform.Find("Hero_SkillA").GetComponent<Image>().sprite
                = ResMgr.Instance.LoadSprite($"GeneralSkill/{s2cMSG.SkillID}");
            if (PlayerMgr.Instance.CheckIsSelfRoles(s2cMSG.RolesID))
            {
                skillA.sprite = ResMgr.Instance.LoadSprite($"GeneralSkill/{s2cMSG.SkillID}");
                skillInfo.gameObject.SetActive(false);
            }
        }
        else 
        {
            rolesDIC[s2cMSG.RolesID].transform.Find("Hero_SkillB").GetComponent<Image>().sprite
                = ResMgr.Instance.LoadSprite($"GeneralSkill/{s2cMSG.SkillID}");
            if (PlayerMgr.Instance.CheckIsSelfRoles(s2cMSG.RolesID))
            {
                skillB.sprite = ResMgr.Instance.LoadSprite($"GeneralSkill/{s2cMSG.SkillID}");
                skillInfo.gameObject.SetActive(false);
            }
        }
    }

    private void OnRoomCloseMsgS2C(BufferEntity res)
    {
        Close();
        RoomMgr.Instance.RemoveRoomInfo();
        UIMgr.Instance.ShowUI(UIType.Lobby);
    }
    /// <summary>
    /// 发送聊天信息
    /// </summary>
    /// <param name="obj"></param>
    private void OnRoomSendMsgS2C(BufferEntity res)
    {
        RoomSendMsgS2C s2cMSG = ProtobufHelper.FromBytes<RoomSendMsgS2C>(res.proto);
        chatText.text += $"{RoomMgr.Instance.GetNickName(s2cMSG.RolesID)}: {s2cMSG.Text}\n";
        chatVertical.value = 0;
    }

    private void OnRoomLockHeroS2C(BufferEntity res)
    {
        RoomLockHeroS2C s2cMSG = ProtobufHelper.FromBytes<RoomLockHeroS2C>(res.proto);
        rolesDIC[s2cMSG.RolesID].transform.Find("Hero_State").GetComponent<Text>().text = "已锁定";
        if (PlayerMgr.Instance.CheckIsSelfRoles(s2cMSG.RolesID))
        {
            isLock = true; //已锁定英雄
        }
    }

    private void OnRoomLoadProgressS2C(BufferEntity res)
    {
        RoomLoadProgressS2C s2cMSG = ProtobufHelper.FromBytes<RoomLoadProgressS2C>(res.proto);
        if (s2cMSG.IsBattleStart)
        {
            ct.Cancel();
            for (int i = 0; i<s2cMSG.RolesID.count; i++)
            {
                playerLoadDic[s2cMSG.RolesID[i]].transform.Find("Progress").GetComponent<Text>().text = "100%";
            }
            async.allowSceneActivation = true;
            Close();
        }
        else
        {
            //如果还不能进入战斗
            for (int i = 0; i<s2cMSG.RolesID.Count; i++)
            {
                playerLoadDic[s2cMSG.RolesID[i]].transform.Find("Progress").GetComponent<Text>().text = $"{s2cMSG.LoadProgress[i]}%";
            }
        }
    }

    private void OnRoomToBattleS2C(BufferEntity res)
    {
        RoomMgr.Instance.InitData();
        RoomToBattleS2C s2cMSG = ProtobufHelper.FromBytes<RoomToBattleS2C>(res.proto);
        RoomMgr.Instance.SavePlayerInfo(s2cMSG.PlayerList);
        transform.Find("LoadBG").gameObject.SetActive(true);
        Transform heroA_item = transform.Find("LoadBG/L_TeamA/HeroA_item");
        Transform heroB_item = transform.Find("LoadBG/L_TeamB/HeroB_item");

        for (int i = 0; i<s2cMSG.PlayerList.Count; i++)
        {
            GameObject go;
            if (s2cMSG.PlayerList[i].TeamID==0)
            {
                go = GameObject.Instantiate(heroA_item.gameObject, heroA_item.parent, false);
            }
            else
            {
                go = GameObject.Instantiate(heroB_item.gameObject, heroB_item.parent, false);
                
            }
            go.GetComponent<Image>().sprite = ResMgr.Instance.LoadSprite($"HeroTexture/{s2cMSG.PlayerList[i].HeroID}");
            go.transform.Find("NickName").GetComponent<Text>().text = s2cMSG.PlayerList[i].RolesInfo.NickName;
            go.transform.Find("SkillA").GetComponent<Image>().sprite 
                = ResMgr.Instance.LoadSprite($"GeneralSkill/{s2cMSG.PlayerList[i].SkillA}");
            go.transform.Find("SkillB").GetComponent<Image>().sprite
                = ResMgr.Instance.LoadSprite($"GeneralSkill/{s2cMSG.PlayerList[i].SkillB}");
            go.transform.Find("Progress").GetComponent<Text>().text = "0%";
            go.gameObject.SetActive(true);
            //缓存克隆出来的游戏物体
            playerLoadDic[s2cMSG.PlayerList[i].RolesInfo.RolesID] = go;
        }
        async = SceneManager.LoadSceneAsync("Battle");
        async.allowSceneActivation = false; //不要激活场景
        SendProgress();
    }

    async void SendProgress()
    {
        await Task.Delay(500);
        Debug.Log($"加载进度。。。。。。。{async.progress * 100}");
        BufferFactory.CreateAndSendPackage(1406, new RoomLoadProgressC2S
        {
            LoadProgress = (int)(async.progress > 0.8 ? 100 : async.progress * 100)
        });
        if (ct.IsCancellationRequested)
        {
            return;
        }
        SendProgress();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        ct.Cancel();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected override void OnRemoveListener()
    {
        base.OnRemoveListener();
        NetEvent.Instance.RemoveEventListener(1400, OnRoomSelectHeroS2C);
        NetEvent.Instance.RemoveEventListener(1401, OnRoomSelectHeroSkillS2C);
        NetEvent.Instance.RemoveEventListener(1403, OnRoomCloseMsgS2C);
        NetEvent.Instance.RemoveEventListener(1404, OnRoomSendMsgS2C);
        NetEvent.Instance.RemoveEventListener(1405, OnRoomLockHeroS2C);
        NetEvent.Instance.RemoveEventListener(1406, OnRoomLoadProgressS2C);
        NetEvent.Instance.RemoveEventListener(1407, OnRoomToBattleS2C);
    }

    protected override void RegisterUIEvent()
    {
        base.RegisterUIEvent();
        for (int i = 0; i<buttonList.Length; i++)
        {
            switch(buttonList[i].name)
            {
                case "Hero1001":
                    buttonList[i].onClick.AddListener(() =>
                    {
                        SendSelectHeroMsg(1001);
                    });
                    break;
                case "Hero1002":
                    buttonList[i].onClick.AddListener(() =>
                    {
                        SendSelectHeroMsg(1002);
                    });
                    break;
                case "Hero1003":
                    buttonList[i].onClick.AddListener(() =>
                    {
                        SendSelectHeroMsg(1003);
                    });
                    break;
                case "Hero1004":
                    buttonList[i].onClick.AddListener(() =>
                    {
                        SendSelectHeroMsg(1004);
                    });
                    break;
                case "Hero1005":
                    buttonList[i].onClick.AddListener(() =>
                    {
                        SendSelectHeroMsg(1005);
                    });
                    break;
                case "Lock":
                    buttonList[i].onClick.AddListener(() =>
                    {
                        if (!isLock)
                        {
                            if (lockHeroID==0)
                            {
                                Debug.Log("请先选择英雄再锁定");
                                return;
                            }
                            isLock = true;
                            BufferFactory.CreateAndSendPackage(1405, new RoomSelectHeroC2S()
                            {
                                HeroID = lockHeroID
                            });
                        }
                    });
                    break;
                case "SkillA":
                    buttonList[i].onClick.AddListener(() =>
                    {
                        OnClickSelectSkill(0);
                    });

                    break;
                case "SkillB":
                    buttonList[i].onClick.AddListener(() =>
                    {
                        OnClickSelectSkill(1);
                    });

                    break;
                case "chengjie":
                    SendSelectSkill(buttonList[i], 101);
                    break;
                case "chuansong":
                    SendSelectSkill(buttonList[i], 102);
                    break;
                case "dianran":
                    SendSelectSkill(buttonList[i], 103);
                    break;
                case "jinhua":
                    SendSelectSkill(buttonList[i], 104);
                    break;
                case "pingzhang":
                    SendSelectSkill(buttonList[i], 105);
                    break;
                case "shanxian":
                    SendSelectSkill(buttonList[i], 106);
                    break;
                case "xuruo":
                    SendSelectSkill(buttonList[i], 107);
                    break;
                case "zhiliao":
                    SendSelectSkill(buttonList[i], 108);
                    break;
                default:
                    break;
            }
        }
    }

    private void SendSelectSkill(Button button, int selectSkillID)
    {
        button.onClick.AddListener(() =>
        {
            skillID = selectSkillID;
            BufferFactory.CreateAndSendPackage(1401, new RoomSelectHeroSkillC2S()
            {
                SkillID = skillID,
                GridID = gridID
            });
        });
    }

    private void OnClickSelectSkill(int selectGridID)
    {
        gridID = selectGridID;
        skillInfo.gameObject.SetActive(true);
    }

    private void SendSelectHeroMsg(int heroID)
    {
        if (!isLock)
        {
            lockHeroID = heroID;
            BufferFactory.CreateAndSendPackage(1400, new RoomSelectHeroC2S()
            {
                HeroID = heroID
            });
        }
    }
}
