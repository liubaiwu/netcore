using System;
using Newtonsoft.Json;

namespace Me.Utils
{
    public class Utils
    {
        //序列化
        public static string Serialize<T>(T t)
        {
           return JsonConvert.SerializeObject(t);
        }

        ///反序列化
        public static T Deserialize<T>(string json)
        {
            if(string.IsNullOrEmpty(json))
            {
                return default(T);
            }
           return (T)JsonConvert.DeserializeObject(json);
        }
    }
}
