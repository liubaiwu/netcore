using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Co.Core.Cache;
using Co.Dao;
using Co.IService;
using Co.Model;
using Co.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SimpleTokenProvider;
using WebApplication.Data;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

        

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            var UseSqlType=Configuration.GetConnectionString("UseSqlType");

            services.AddSingleton<ICacheManager>(new RedisCacheManager(Configuration.GetConnectionString("CommRedisConnection")));
            if(UseSqlType=="MySql"){
                services.AddSingleton<DapperFactory>(new MySqlDapperFactory(Configuration.GetConnectionString("sqlConnectionString")));//数据库连接
            }else if(UseSqlType=="SQLServer"){
                services.AddSingleton<DapperFactory>(new SqlDapperFactory(Configuration.GetConnectionString("sqlConnectionString")));//数据库连接
            }
            //services.AddTransient();// s=new ();
            services.AddTransient<IBaseService<AD>,BaseService<AD>>();

            

        }
 
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            
            app.UseIdentity();
            /*
                        var secretKey = "mysupersecret_secretkey!123";
                        var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
                    
                        // Add JWT generation endpoint:
                
                        var options = new TokenProviderOptions
                        {
                            Audience = "ExampleAudience",
                            Issuer = "ExampleIssuer",
                            SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                        };
            
                        app.UseMiddleware<TokenProviderMiddleware>(Options.Create(options));



                        // Add external authentication middleware below. To configure them please see https://go.microsoft.com/fwlink/?LinkID=532715
            */

            var audienceConfig = Configuration.GetSection("Audience");//从配置文件获取配置集合
              var symmetricKeyAsBase64 = audienceConfig["Secret"];//获取配置集合中具体的配置项
              var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
              var signingKey = new SymmetricSecurityKey(keyByteArray);
  
              app.UseTokenProvider(new TokenProviderOptions
             {
                 Audience = "Catcher Wong",
                 Issuer = "http://catcher1994.cnblogs.com/",
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
             });


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        
    }
}
