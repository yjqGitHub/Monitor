using JQ.Extensions;
using JQ.ValidateCode;
using JQ.Web;
using JQ.Web.Tool.Filters;
using JQ.Web.Tool.ViewResults;
using Monitor.IUserApplication;
using Monitor.SSO.WebManage.Models;
using Monitor.Web.Tool;
using Monitor.Web.Tool.Authority;
using Monitor.Web.Tool.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Monitor.SSO.WebManage.Controllers
{
    [Monitor]
    public class AuthorityController : Controller
    {
        private readonly IWebSiteApplication _webSiteApplication;
        private readonly IAuthorityApplication _authorityApplication;

        public AuthorityController(IWebSiteApplication webSiteApplication, IAuthorityApplication authorityApplication)
        {
            _webSiteApplication = webSiteApplication;
            _authorityApplication = authorityApplication;
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
                    var userToken = WebTool.GetCurrentUserToken();
                    if (userToken.IsNotNullAndNotWhiteSpace())
                    {
                        var checkeResult = _authorityApplication.CheckTokenIsAvailable(userToken);
                        if (checkeResult.IsSuccess)
                        {
                            backUrl = WebTool.GetBackUrl(operateResult.Value?.SiteDefaultBackUrl, backUrl, new Dictionary<string, string>
                            {
                                ["token"] = userToken
                            });
                            return Redirect(backUrl);
                        }
                    }
                    ViewBag.SiteInfo = operateResult.Value;
                    ViewBag.BackUrl = backUrl.IsNullOrWhiteSpace() ? operateResult.Value.SiteDefaultBackUrl : backUrl;
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
        public async Task<JQJsonResult> Authority(AuthoryModel model)
        {
            if (!WebTool.CheckCode(model.Code))
            {
                return JQJsonResult.ParamError("请输入正确的验证码");
            }
            var operateResult = await _authorityApplication.AuthorityAsync(model.AppId, model.UserName, model.Pwd);
            if (operateResult.SuccessAndValueNotNull)
            {
                WebTool.SetCurrentUserToken(operateResult.Value);
                EnhancedUriBuilder uriBuilder = new EnhancedUriBuilder(model.BackUrl);
                uriBuilder.QueryItems["token"] = operateResult.Value;
                return JQJsonResult.Success("授权成功", new { BackUrl = uriBuilder.ToString() });
            }
            else
            {
                return JQJsonResult.Create(operateResult);
            }
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
        [HttpPost]
        [Validate]
        public JQJsonResult Check(AuthorityCheckModel model)
        {
            var operateResult = _webSiteApplication.GetSite(model.AppId);
            if (operateResult.SuccessAndValueNotNull)
            {
                if (model.CheckSign(operateResult.Value.AppSecret))
                {
                    var checkeResult = _authorityApplication.CheckTokenIsAvailable(model.Token);
                    if (checkeResult.IsSuccess)
                    {
                        return JQJsonResult.Success("token校验成功", null);
                    }
                    else
                    {
                        return JQJsonResult.ParamError("token已过期");
                    }
                }
            }
            return JQJsonResult.ParamError("签名错误");
        }
    }
}