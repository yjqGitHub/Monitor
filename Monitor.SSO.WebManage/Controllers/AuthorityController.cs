using JQ.Web.Tool.ViewResults;
using Monitor.Web.Tool.Authority;
using System.Web.Mvc;
using JQ.Extensions;

namespace Monitor.SSO.WebManage.Controllers
{
    public class AuthorityController : Controller
    {
        // GET: Authority
        public ActionResult Index(string backUrl, string appId)
        {
            if (appId.IsNotNullAndNotWhiteSpace())
            {
                ViewBag.BackUrl = backUrl;
                ViewBag.AppId = appId;
            }
            return View("~/Views/Shared/404.cshtml");
        }

        /// <summary>
        /// 授权认证
        /// </summary>
        /// <returns>认证结果</returns>
        [HttpGet]
        public JQJsonResult Check(AuthorityCheckModel model)
        {
            return JQJsonResult.Success("签名校验成功", null);
        }
    }
}