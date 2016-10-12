using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Data.SqlClient;
using Co.Core.Cache;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        ICacheManager _cache;

        public HomeController(ICacheManager c)
        {
                this._cache=c;
        }

        public IActionResult Index()
        {
            SqlConnection con = new SqlConnection("server=120.24.171.142;database=kuaiyidaidb_test;uid=sa;pwd=duoyingABC;");
            var list=con.Query<dynamic>("select top 10 * from god where FullName is not null");
            ViewData["godlist"]=list;
            con.Close();
             

            _cache.Set<string>("a","1");

            var dd= _cache.Get<string>("a");


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
    }
}
