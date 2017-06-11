using JQ.ValidateCode;
using System.Web.Mvc;

namespace Monitor.WebManage.Controllers
{
    public class AccountController : Controller
    {
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
            var codeInfo = coder.CreateImage(6, ValidateCodeType.NumberAndLetter);
            VerificationCodeHelper.SetCode(codeInfo.Item1);
            return File(codeInfo.Item2, @"image/Png");
        }
    }
}