using AndiDance.Data;
using AndiDance.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndiDance.UI.Controllers
{
    public class StatisticsController : Controller
    {
        private StatisticsDomainModel domainModel = new StatisticsDomainModel();

        /// <summary>
        /// 课程安排页面
        /// </summary>
        /// <returns></returns>
        public ActionResult CourseScheduleView()
        {
            return View();
        }
        /// <summary>
        /// 获取课程安排数据
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <returns></returns>
        public JsonResult GetCourseSchedule(string dayOfWeek)
        {
            List<CourseSchedule> courseScheduleList = domainModel.GetCourseSchedule(dayOfWeek);
            return Json(courseScheduleList);
        }
    }
}