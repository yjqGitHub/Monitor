﻿using JQ.ValidateCode;
using JQ.Web.Tool.Filters;
using JQ.Web.Tool.ViewResults;
using Monitor.AdminManage.Models;
using System.Web.Mvc;

namespace Monitor.AdminManage.Controllers
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
            var codeInfo = coder.CreateImage(6, ValidateCodeType.Number);
            VerificationCodeHelper.SetCode(codeInfo.Item1);
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
            return JQJsonResult.Success("登录成功", null);
        }
    }
}