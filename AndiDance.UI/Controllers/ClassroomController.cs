using AndiDance.Data;
using AndiDance.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndiDance.UI.Controllers
{
    public class ClassroomController : Controller
    {
        private ClassroomDomainModel domainModel = new ClassroomDomainModel();

        /// <summary>
        /// 教室设置页面
        /// </summary>
        /// <returns></returns>
        public ActionResult ClassroomSettingView()
        {
            return View();
        }
        /// <summary>
        /// 获取所有教室列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllClassrooms()
        {
            List<Classroom> classroomList = domainModel.GetAllClassrooms();
            return Json(classroomList);
        }
        /// <summary>
        /// 添加教室
        /// </summary>
        /// <param name="classroom"></param>
        /// <returns></returns>
        public bool AddClassroom(Classroom classroom)
        {
            return domainModel.AddClassroom(classroom);
        }
        /// <summary>
        /// 获取教室信息
        /// </summary>
        /// <param name="classroomId"></param>
        /// <returns></returns>
        public JsonResult GetClassroomDetail(int classroomId)
        {
            Classroom classroom = domainModel.GetClassroomDetail(classroomId);
            return Json(classroom);
        }
    }
}