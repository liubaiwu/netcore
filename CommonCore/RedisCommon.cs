
using StackExchange.Redis;
using Me.Utils;
namespace CommonCore
{
    public class RedisCommon
    {
        private ConnectionMultiplexer _redis = null;
        private IDatabase _db;

        private IServer _server;
        public RedisCommon(string ip,int port,string password)
        {    
            _redis= ConnectionMultiplexer.Connect(ip+":"+port+",password:"+password);
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