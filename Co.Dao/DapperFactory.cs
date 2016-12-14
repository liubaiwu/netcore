
using System.Data;

namespace Co.Dao
{
    //数据库工厂
    public abstract class DapperFactory
    {
        protected static  IDbConnection _conn;
        protected static readonly object locker=new object();

        protected string _connectionString;

        //创建连接
        public abstract IDbConnection Create();
    }
}
