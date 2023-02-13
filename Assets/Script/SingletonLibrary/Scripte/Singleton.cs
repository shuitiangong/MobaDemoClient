using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Singleton<T> where T:new()//T 约束 只能是class类型的
{
    static T instance;

    public static T Instance
    {
        get {
            if (instance==null)
            {
                instance = new T();
            }
            return instance;
        }
    }

}
