using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;
using Co.Core.Cache;
using Co.IService;
using Co.Model;
using Co.Service;
using MySql.Data.MySqlClient;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        ICacheManager _cache;
        IBaseService<AD> _s;
        public HomeController(ICacheManager c,IBaseService<AD> s)
        {
                this._cache=c;
                this._s=s;
        }
        public IActionResult Index(int Id=1)
        {
/*
            var cName=new Claim(ClaimTypes.Name, "奥巴马");//证件单元
          

           var ci= new ClaimsIdentity();//建立身份证
           ci.AddClaim(cName);
           
            
           var cp=new ClaimsPrincipal();//证件当事人
           cp.AddIdentity(ci);
           

            var user = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, "奥巴马") }, CookieAuthenticationDefaults.AuthenticationScheme));
            //await
             HttpContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user);


            */
            /*SqlConnection con = new SqlConnection("server=120.24.171.142;database=kuaiyidaidb_test;uid=sa;pwd=duoyingABC;");
            var list=con.Query<dynamic>("select top 10 * from god where FullName is not null");
            ViewData["godlist"]=list;
            con.Close();
             
            MySqlConnection conn=new MySqlConnection("server=192.168.2.46;database=test;uid=root;pwd=123456;charset='gbk';SslMode=None");
            var list11= conn.Query<dynamic>("select * from AD").ToList();
            */

            
            /*

            var test=1;
            var x=  _s.GetById(Id);

           ViewBag.Ad=x;
*/

            

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Ad(int  a,int b)
        {
            return Content((a+b).ToString());
        }
    }
}
