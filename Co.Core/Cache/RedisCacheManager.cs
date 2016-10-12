using System;
using Co.Utils;
using StackExchange.Redis;

namespace Co.Core.Cache
{
    public class RedisCacheManager : ICacheManager
    {
        private static object _locker = new object();  
        private IDatabase Cache;
        public RedisCacheManager(string connectionString,int db=-1,object asyncStatus=null)
        {
            Cache=RedisHelper.GetDataBase(connectionString,db,asyncStatus);
        }

        ///获取缓存
        public T Get<T>(string key)
        {
            lock(_locker){
            string val= Cache.StringGet(key);
            if(string.IsNullOrEmpty(val))
                return default(T);
            return UtilsHelper.Deserialize<T>(val);
            }
        }
        ///设置缓存
        public bool Set<T>(string key, T t)
        {
            lock(_locker){
            return Cache.StringSet(key,UtilsHelper.Serialize<T>(t));
            }
        }
    }
}