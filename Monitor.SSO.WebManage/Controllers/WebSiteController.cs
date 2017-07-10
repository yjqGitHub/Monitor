using Monitor.IUserApplication;
using Monitor.SSO.WebManage.Models;
using Monitor.TransDto.WebSite;
using Monitor.Web.Tool.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Monitor.SSO.WebManage.Controllers
{
    [Monitor]
    [IsAuthority]
    public class WebSiteController : Controller
    {
        private readonly IWebSiteApplication _webSiteApplication;
        public WebSiteController(IWebSiteApplication webSiteApplication)
        {
            _webSiteApplication = webSiteApplication;
        }

        public ActionResult Index(WebSiteQueryWhereDto queryWhere)
        {
            var operateResult = _webSiteApplication.LoadWebSiteList(queryWhere);
            if (!operateResult.IsSuccess)
            {
                ModelState.AddModelError("Error", operateResult.Message);
            }
            ViewBag.SearchInfo = queryWhere;
            return View(operateResult.Value);
        }

        public ActionResult Add()
        {
            return View(new WebSiteModel());
        }
    }
}