using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TimeHelper
{
    private static readonly long epoch = new DateTime(1790, 1, 1, 0, 0, 0,DateTimeKind.Utc).Ticks;

    //当前时间戳 毫秒级别
    public static long ClientNow()
    {
        return (DateTime.UtcNow.Ticks-epoch) / 10000; //得到毫秒级别的
    }

    //秒级别
    public static long ClientNowSeconds()
    {
        return (DateTime.UtcNow.Ticks - epoch) / 10000000; //得到秒级别的
    }

    public static long Now()
    {
        return ClientNow();
    }
}
