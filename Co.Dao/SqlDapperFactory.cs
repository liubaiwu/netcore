using System.Data;
using System.Data.SqlClient;

namespace Co.Dao
{
    //数据库工厂
    public sealed class SqlDapperFactory : DapperFactory
    {
        /*
        private static  IDbConnection _conn;
        string _connectionString;
        private static readonly object locker=new object();
        */
        ///初始化连接
        public SqlDapperFactory(string connectionString)
        {
            _connectionString=connectionString;
        }
        ///创建连接
        public override IDbConnection Create()
        {
            if(_conn==null)
            {
                lock(locker)
                {
                    if(_conn==null)
                    {
                        _conn=new SqlConnection(_connectionString);
                    }
                }
            }
            return _conn;
            
        }
    }
}
