using JQ.ValidateCode;
using Monitor.Web.Tool;
using System.Web.Mvc;

namespace Monitor.SSO.WebManage.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login(string backUrl)
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
    }
}