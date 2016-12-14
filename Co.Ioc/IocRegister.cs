using System;
using System.Collections.Generic;
using System.Text;
using Co.Core.Cache;
using Co.Dao;
using Co.IService;
using Co.Model;
using Co.Service;

namespace Co.Ioc
{
    public class IocRegister
    {
        ///// <summary>
        ///// 注入
        ///// </summary>
        ///// <param name="Configuration"></param>
        ///// <param name="services"></param>
        //public static void Init(IConfigurationRoot Configuration, IServiceCollection services)
        //{
            
            
        //    var UseSqlType = Configuration.GetConnectionString("UseSqlType");//选择数据库类型

        //    services.AddSingleton<ICacheManager>(new RedisCacheManager(Configuration.GetConnectionString("CommRedisConnection")));
        //    if (UseSqlType == "MySql")
        //    {
        //        services.AddSingleton<DapperFactory>(new MySqlDapperFactory(Configuration.GetConnectionString("sqlConnectionString")));//数据库连接
        //    }
        //    else if (UseSqlType == "SQLServer")
        //    {
        //        services.AddSingleton<DapperFactory>(new SqlDapperFactory(Configuration.GetConnectionString("sqlConnectionString")));//数据库连接
        //    }
        //    //services.AddTransient();// s=new ();
        //    services.AddTransient<IBaseService<AD>, BaseService<AD>>();
        //}
    }
}
