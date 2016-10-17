using System.Data;
using MySql.Data.MySqlClient;

namespace Co.Dao
{
    //数据库工厂
    public sealed class MySqlDapperFactory : DapperFactory
    {
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
                        _conn=new MySqlConnection(_connectionString);
                    }
                }
            }
            return _conn;
            
        }
    }
}
