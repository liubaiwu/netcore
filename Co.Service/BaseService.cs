using System;
using Co.IService;
using Co.Dao;
using Dapper;
using System.Linq;
using Co.Core.Cache;
using System.Data;

namespace Co.Service
{
    public class BaseService<T> : IBaseService<T> where T:class
    {
        string TableName=typeof(T).Name;
        DapperFactory _dapperFactory;
        ICacheManager _cache;
        public BaseService(DapperFactory dapperFactory,ICacheManager cache)
        {
            _dapperFactory=dapperFactory;
            _cache=cache;
        }

        public T GetById(int Id)
        {
            string key=string.Format("DbCache-{0}-{1}",TableName,Id);
            var val=_cache.Get<T>(key);
            if(val==null)
            {
                var p = new DynamicParameters();
                p.Add("@Id",Id, DbType.Int32);
                val=_dapperFactory.Create().Query<T>("select * from "+TableName +" where Id=@Id",p).FirstOrDefault();
                _cache.Set<T>(key,val);
            }
             return val;
        }

        public int Insert(T t)
        {
            throw new NotImplementedException();
        }
    }
}
