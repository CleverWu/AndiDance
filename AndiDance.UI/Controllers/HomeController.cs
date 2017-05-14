using AndiDance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndiDance.UI.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// 首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        #region 今日情况
        /// <summary>
        /// 今日新增会员页面
        /// </summary>
        /// <returns></returns>
        public ActionResult NewMembersTodayView()
        {
            return View();
        }
        /// <summary>
        /// 今日新增储值页面
        /// </summary>
        /// <returns></returns>
        public ActionResult NewChargeBillsTodayView()
        {
            return View();
        }
        /// <summary>
        /// 今日新增开单页面
        /// </summary>
        /// <returns></returns>
        public ActionResult NewPackageBillsTodayView()
        {
            return View();
        }
        #endregion
    }
}