using System.Collections;
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
            Debug.LogError($"没有找到UI窗体：{path}");
            return null;
        }
        GameObject obj = GameObject.Instantiate(res);
        return obj;
    }
}
