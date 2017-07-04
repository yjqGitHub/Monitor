using JQ.Extensions;
using JQ.ValidateCode;
using JQ.Web.Tool.Filters;
using JQ.Web.Tool.ViewResults;
using Monitor.IUserApplication;
using Monitor.SSO.WebManage.Models;
using Monitor.Web.Tool;
using Monitor.Web.Tool.Authority;
using System.Web.Mvc;

namespace Monitor.SSO.WebManage.Controllers
{
    public class AuthorityController : Controller
    {
        private readonly IWebSiteApplication _webSiteApplication;
        private readonly IAdminApplication _adminApplication;

        public AuthorityController(IWebSiteApplication webSiteApplication, IAdminApplication adminApplication)
        {
            _webSiteApplication = webSiteApplication;
            _adminApplication = adminApplication;
        }

        /// <summary>
        /// 授权页面
        /// </summary>
        /// <param name="backUrl">授权反馈地址</param>
        /// <param name="appId">appId</param>
        /// <returns></returns>
        public ActionResult Index(string backUrl, string appId)
        {
            if (appId.IsNotNullAndNotWhiteSpace())
            {
                var operateResult = _webSiteApplication.GetSite(appId);
                if (operateResult.SuccessAndValueNotNull)
                {
                    ViewBag.SiteInfo = operateResult.Value;
                    //ViewBag.BackUrl = backUrl.IsNullOrWhiteSpace() ? operateResult.Value.SiteDefaultBackUrl : backUrl;
                    ViewBag.BackUrl = operateResult.Value.SiteDefaultBackUrl ?? "/Home/Index";
                    return View();
                }
            }
            return View("~/Views/Shared/404.cshtml");
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="model">需要授权用户信息</param>
        /// <returns></returns>
        [HttpPost]
        [Validate]
        public JQJsonResult Authority(AuthoryModel model)
        {
            if (!WebTool.CheckCode(model.Code))
            {
                return JQJsonResult.ParamError("请输入正确的验证码");
            }
            var operateResult = _adminApplication.Login(model.UserName, model.Pwd);
            if (operateResult.IsSuccess)
            {
                WebTool.SetCurrentLoginUser(operateResult.Value);
            }
            else
            {
                return JQJsonResult.Create(operateResult);
            }
            return JQJsonResult.Success("登录成功", null);
        }

        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public FileResult ValidateCode()
        {
            ValidateCoder coder = new ValidateCoder();
            var codeInfo = coder.CreateImage(6, ValidateCodeType.Number);
            WebTool.SetCode(codeInfo.Item1);
            return File(codeInfo.Item2, @"image/Png");
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