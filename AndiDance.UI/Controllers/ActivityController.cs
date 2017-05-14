using AndiDance.Data;
using AndiDance.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndiDance.UI.Controllers
{
    public class ActivityController : Controller
    {
        private ActivityDomainModel domainModel = new ActivityDomainModel();

        /// <summary>
        /// 活动设置页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ActivitySettingView()
        {
            return View();
        }
        /// <summary>
        /// 获取所有活动列表
        /// </summary>
        /// <param name="activityName"></param>
        /// <returns></returns>
        public JsonResult GetAllActivities(string activityName)
        {
            List<Activity> activityList = domainModel.GetAllActivities(activityName);
            return Json(activityList);
        }
        /// <summary>
        /// 活动添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ActivityAddingView()
        {
            return View();
        }
        /// <summary>
        /// 添加活动
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public bool AddActivity(Activity activity)
        {
            return domainModel.AddActivity(activity);
        }
        /// <summary>
        /// 活动详情页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ActivityDetailView()
        {
            return View();
        }
        /// <summary>
        /// 获取活动详情
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public JsonResult GetActivityDetail(int activityId)
        {
            Activity activity = domainModel.GetActivityDetail(activityId);
            return Json(activity);
        }
        /// <summary>
        /// 为活动添加套餐应用
        /// </summary>
        /// <param name="packageId"></param>
        /// <param name="activityId"></param>
        /// <param name="activityPrice"></param>
        /// <param name="activityHour"></param>
        /// <param name="activityDuration"></param>
        /// <returns></returns>
        public bool AddPackageToActivity(int packageId, int activityId, double activityPrice, int activityHour, int activityDuration)
        {
            return domainModel.AddPackageToActivity(packageId, activityId, activityPrice, activityHour, activityDuration);
        }
    }
}