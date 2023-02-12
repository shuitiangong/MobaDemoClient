using Google.Protobuf;
using LitJson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class JsonHelper
{
    /// <summary>  
    /// 将对象序列化为JSON格式  
    /// </summary>  
    /// <param name="o">对象</param>  
    /// <returns>json字符串</returns>  
    public static string SerializeObject(object o)
    {
        JsonMapper.RegisterExporter<float>((obj, writer) => writer.Write(Convert.ToDouble(obj)));
        //LitJson本身不支持float类型的数据  这里将它进行转换成 double
        JsonMapper.RegisterImporter<double, float>(input => Convert.ToSingle(input));
        string json = JsonMapper.ToJson(o);
        return json;
    }

    public static void Log(int messageID,IMessage message) {

        Debug.Log($"报文ID:{messageID}\n包体{JsonHelper.SerializeObject(message)}");
    }


}