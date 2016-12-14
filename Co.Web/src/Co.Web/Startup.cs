using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Co.Core.Cache;
using Co.Dao;
using Co.IService;
using Co.Model;
using Co.Service;

namespace Co.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            InitIoc(Configuration, services);
            // Add framework services.
            services.AddMvc();
        }



        private void InitIoc(IConfigurationRoot Configuration, IServiceCollection services)
        {
            var UseSqlType = Configuration.GetConnectionString("UseSqlType");

            services.AddSingleton<ICacheManager>(new RedisCacheManager(Configuration.GetConnectionString("CommRedisConnection")));
            if (UseSqlType == "MySql")
            {
                services.AddSingleton<DapperFactory>(new MySqlDapperFactory(Configuration.GetConnectionString("sqlConnectionString")));//数据库连接
            }
            else if (UseSqlType == "SQLServer")
            {
                services.AddSingleton<DapperFactory>(new SqlDapperFactory(Configuration.GetConnectionString("sqlConnectionString")));//数据库连接
            }
            //services.AddTransient();// s=new ();
            services.AddTransient<IBaseService<AD>, BaseService<AD>>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
