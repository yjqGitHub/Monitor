using Monitor.SSO.WebManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Monitor.SSO.WebManage.Controllers
{
    public class AuthorityController : Controller
    {
        // GET: Authority
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 授权认证
        /// </summary>
        /// <returns>认证结果</returns>
        [HttpGet]
        public JsonResult Check(AuthorityCheckModel model)
        {
            return null;
        }
    }
}