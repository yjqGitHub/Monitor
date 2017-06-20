using JQ.ValidateCode;
using JQ.Web.Tool.Filters;
using JQ.Web.Tool.ViewResults;
using Monitor.AdminManage.Models;
using Monitor.IUserApplication;
using Monitor.Web.Tool;
using System.Web.Mvc;

namespace Monitor.AdminManage.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAdminApplication _adminApplication;

        public AccountController(IAdminApplication adminApplication)
        {
            _adminApplication = adminApplication;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
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
        /// 登录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Validate]
        public JQJsonResult Login(AccountModel model)
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
    }
}