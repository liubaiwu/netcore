using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Co.Core.Cache;
using Co.IService;
using Co.Model;

namespace Co.Web.Controllers
{
    public class HomeController : Controller
    {

        ICacheManager _cache;
        IBaseService<AD> _s;
        public HomeController(ICacheManager c, IBaseService<AD> s)
        {
            this._cache = c;
            this._s = s;
        }
        public IActionResult Index()
        {

            var x = _s.GetById(1);

            ViewBag.Ad = x;
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
