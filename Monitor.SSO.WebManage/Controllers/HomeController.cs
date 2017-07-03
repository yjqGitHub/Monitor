using Monitor.Web.Tool.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Monitor.SSO.WebManage.Controllers
{
    [Login]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [Login]
        [HttpPost]
        public ActionResult Test()
        {
            return null;
        }
    }
}