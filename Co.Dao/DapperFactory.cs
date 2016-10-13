
using System.Data;

namespace Co.Dao
{
    //数据库工厂
    public abstract class DapperFactory
    {
        //创建连接
        public abstract IDbConnection Create();
    }
}
