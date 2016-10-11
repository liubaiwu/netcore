
using StackExchange.Redis;
using Me.Utils;
<<<<<<< HEAD
using System;

=======
>>>>>>> ee6cd6457b956e6a1a9e6e16cbc737e56ec6a9e5
namespace CommonCore
{
    public class RedisCommon
    {
        private ConnectionMultiplexer _redis = null;
        private IDatabase _db;

        private IServer _server;
<<<<<<< HEAD
        ConfigurationOptions option=new ConfigurationOptions();
        public RedisCommon(string ip,int port,string password)
        {    
            /*
            var configurationOptions = new ConfigurationOptions
            {
                EndPoints =
                {
                    { ip, port }
                },
                KeepAlive = 180,
                Password =password,
                // Needed for cache clear
                AllowAdmin = true
            };

            var connectionMultiplexer = ConnectionMultiplexer.Connect(configurationOptions );
            */
            if(string.IsNullOrEmpty(password))
            {
                _redis= ConnectionMultiplexer.Connect(ip+":"+port);
            }
            else{
                _redis= ConnectionMultiplexer.Connect(ip+":"+port+",password:"+password);
            }
=======
        public RedisCommon(string ip,int port,string password)
        {    
            _redis= ConnectionMultiplexer.Connect(ip+":"+port+",password:"+password);
>>>>>>> ee6cd6457b956e6a1a9e6e16cbc737e56ec6a9e5
            _db = _redis.GetDatabase();
            _server = _redis.GetServer(ip, port);
        }
        ///设置缓存
        public void Set<T>(string key,T t)
        {
            _db.StringSet(key,Utils.Serialize<T>(t));
        }
        ///获取缓存
        public T Get<T>(string key)
        {
            return Utils.Deserialize<T>(_db.StringGet(key)) ;
        }
    }
}