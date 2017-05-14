using AndiDance.Data;
using AndiDance.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndiDance.UI.Controllers
{
    public class CourseController : Controller
    {
        private CourseDomainModel domainModel = new CourseDomainModel();

        /// <summary>
        /// 课程设置页面
        /// </summary>
        /// <returns></returns>
        public ActionResult CourseSettingView()
        {
            return View();
        }
        /// <summary>
        /// 获取所有课程列表
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public JsonResult GetAllCourses(string courseName)
        {
            List<Course> courseList = domainModel.GetAllCourses(courseName);
            return Json(courseList);
        }
        /// <summary>
        /// 添加课程页面
        /// </summary>
        /// <returns></returns>
        public ActionResult CourseAddingView()
        {
            return View();
        }
        /// <summary>
        /// 添加课程
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public bool AddCourse(Course course)
        {
            return domainModel.AddCourse(course);
        }
        /// <summary>
        /// 课程详情页面
        /// </summary>
        /// <returns></returns>
        public ActionResult CourseDetailView()
        {
            return View();
        }
        /// <summary>
        /// 获取课程信息
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public JsonResult GetCourseDetail(int courseId)
        {
            Course course = domainModel.GetCourseDetail(courseId);
            return Json(course);
        }
    }
}