﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResMgr: Singleton<ResMgr>
{
    //加载UI窗体
    public GameObject LoadUI(string path)
    {
        GameObject res = Resources.Load<GameObject>($"UIPrefab/{path}");
        if (res==null)
        {
            Debug.LogError($"没有找到UI窗体：UIPrefab/{path}");
            return null;
        }
        return res;
    }

    //加载Sprite
    public Sprite LoadSprite(string path)
    {
        Sprite sprite = Resources.Load<Sprite>($"Image/{path}");
        if (sprite==null)
        {
            Debug.LogError($"没有找到图片：{path}");
            return null;
        }
        return sprite;
    }

    //加载模型
    public GameObject LoadModel(string path)
    {
        GameObject res = Resources.Load<GameObject>($"Model/{path}");
        if (res == null)
        {
            Debug.LogError($"没有找到模型：Model/{path}");
            return null;
        }
        return GameObject.Instantiate(res);
    }

    //加载特效
    public GameObject LoadEffect(int heroID, string skillName)
    {
        GameObject res = Resources.Load<GameObject>($"Hero/{heroID}/Effect/{skillName}");
        return GameObject.Instantiate(res);
    }
}
