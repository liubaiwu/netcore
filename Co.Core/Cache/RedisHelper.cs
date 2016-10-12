using StackExchange.Redis;
using System.Collections.Generic;

namespace Co.Core.Cache
{
    public class RedisHelper
    {
        private static Dictionary<string, ConnectionMultiplexer> dicMap = new Dictionary<string, ConnectionMultiplexer>();//连接池记录
        /// 锁对象        
        private static object _locker = new object();  

        /// StackExchange.Redis对象        
        private static ConnectionMultiplexer instance;  

        private static string ConnectionString=string.Empty;

        private static void SetConnection(string connection)
        {
            ConnectionString=connection;
        }

        private static ConnectionMultiplexer Instance        
        {            
            get            
            {   if(dicMap!=null && dicMap.Count > 0)
                {
                    instance=dicMap[ConnectionString];
                }      
                if (instance == null)               
                {                    
                    lock (_locker)                   
                    {                        
                        if (instance != null)                           
                            return instance;                       
                        instance = ConnectionMultiplexer.Connect(ConnectionString);
                        dicMap[ConnectionString]=instance;                     
                        return instance;                    
                    }                
                }                
                return instance;            
            }        
        } 
        ///获取操作的db
        public static IDatabase GetDataBase(string connectionString,int dbIndex=-1,object asyncStatus=null)
        {
            SetConnection(connectionString);
            var i=Instance;
            return i.GetDatabase(dbIndex,asyncStatus);
        }



    }
}