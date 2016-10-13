using System.Data;

namespace Co.Dao
{
    //数据库工厂
    public sealed class MySqlDapperFactory : DapperFactory
    {
        private static  IDbConnection _conn;
        private static readonly object locker=new object();

        string _connectionString;
        public MySqlDapperFactory(string connectionString)
        {
            _connectionString=connectionString;
        }

        public override IDbConnection Create()
        {
            if(_conn==null)
            {
                lock(locker)
                {
                    if(_conn==null)
                    {
                        
                    }
                }
            }
            return _conn;
            
        }
    }
}
