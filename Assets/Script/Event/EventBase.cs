using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;

public class EventBase<T,P,X> where T:new () where P:class
{
    //1.子类 什么类型
    //2.
    //3.

    private static T instance;
    public static T Instance {
        get {
            if (instance==null)
            {
                instance = new T();
            }
            return instance;
        }
    }

    //存储事件ID 还有方法(委托) 
    //使用线程安全的字典 避免以后多线程环境下出现问题
   public ConcurrentDictionary<X, List<Action<P>>> dic = new ConcurrentDictionary<X, List<Action<P>>>();

    //添加事件
    public void AddEventListener(X key,Action<P> handle) {
        if (dic.ContainsKey(key))
        {
            dic[key].Add(handle);
        }
        else
        {
            List<Action<P>> actions = new List<Action<P>>();
            actions.Add(handle);
            dic[key] = actions;
        }
    }


    //移除事件
    public void RemoveEventListener(X key, Action<P> handle) {
        if (dic.ContainsKey(key))
        {
            List<Action<P>> actions = dic[key];
            actions.Remove(handle);

            if (actions.Count==0)
            {
                List<Action<P>> removeActions;
                dic.TryRemove(key,out removeActions);
            }
        }
    }

    //派发事件的接口-带有参数
    public void Dispatch(X key,P p) {
        if (dic.ContainsKey(key))
        {
            List<Action<P>> actions = dic[key];
            if (actions!=null&&actions.Count>0)
            {
                for (int i = 0; i < actions.Count; i++)
                {
                    if (actions[i]!=null)
                    {
                        actions[i](p);
                    }
                }
            }
        }
    }

    //派发事件的接口-没有参数的
    public void Dispatch(X key) {
        Dispatch(key, null);
    }
}
