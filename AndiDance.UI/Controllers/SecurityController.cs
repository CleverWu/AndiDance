using AndiDance.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndiDance.UI.Controllers
{
    public class SecurityController : Controller
    {
        private SecurityDomainModel domainModel = new SecurityDomainModel();

        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// 提交用户密码并返回验证结果
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool SubmitCredentials(string account, string password)
        {
            return domainModel.SubmitCredentials(account, password);
        }
    }
}