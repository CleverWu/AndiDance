using AndiDance.Data;
using AndiDance.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndiDance.UI.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeDomainModel domainModel = new EmployeeDomainModel();

        /// <summary>
        /// 员工管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult EmployeeManagementView()
        {
            return View();
        }
        /// <summary>
        /// 获取相关员工列表数据
        /// </summary>
        /// <param name="jobStatus">任职情况（在职，离职）</param>
        /// <param name="position">职位</param>
        /// <param name="employeeName">员工名</param>
        /// <returns></returns>
        public JsonResult GetAllEmployees(string jobStatus, string position, string employeeName)
        {
            List<Employee> employeeList = domainModel.GetAllEmployees(jobStatus, position, employeeName);
            return Json(employeeList);
        }
        /// <summary>
        /// 添加员工页面
        /// </summary>
        /// <returns></returns>
        public ActionResult EmployeeAddingView()
        {
            return View();
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool AddEmployee(Employee employee)
        {
            return domainModel.AddEmployee(employee);
        }
        /// <summary>
        /// 员工详情页面
        /// </summary>
        /// <returns></returns>
        public ActionResult EmployeeDetailView()
        {
            return View();
        }
        /// <summary>
        /// 获取员工详情
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public JsonResult GetEmployeeDetail(int employeeId)
        {
            Employee employee = domainModel.GetEmployeeDetail(employeeId);
            return Json(employee);
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public bool DeleteEmployee(int employeeId)
        {
            return domainModel.DeleteEmployee(employeeId);
        }
        /// <summary>
        /// 代课
        /// </summary>
        /// <param name="subEmployeeId">课程id</param>
        /// <param name="subEmployeeId">代课员工id</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public bool SubstituteCourseSchedule(int courseScheduleId, int subEmployeeId, string startTime, string endTime)
        {
            return domainModel.SubstituteCourseSchedule(courseScheduleId, subEmployeeId, startTime, endTime);
        }
        /// <summary>
        /// 停课
        /// </summary>
        /// <param name="courseScheduleId">课程id</param>
        /// <returns></returns>
        public bool SuspendCourseSchedule(int courseScheduleId)
        {
            return domainModel.SuspendCourseSchedule(courseScheduleId);
        }
        /// <summary>
        /// 恢复上课
        /// </summary>
        /// <param name="courseScheduleId">课程id</param>
        /// <returns></returns>
        public bool ResumeCourseSchedule(int courseScheduleId)
        {
            return domainModel.ResumeCourseSchedule(courseScheduleId);
        }
        /// <summary>
        /// 员工离职
        /// </summary>
        /// <param name="employeeId">员工id</param>
        /// <param name="dismissionReason">离职原因</param>
        /// <returns></returns>
        public bool DismissEmployee(int employeeId, string dismissionReason)
        {
            return domainModel.DismissEmployee(employeeId, dismissionReason);
        }
        /// <summary>
        /// 获取所有教师列表
        /// </summary>
        /// <returns></returns>
        public JsonResult GetAllTeachers()
        {
            List<Employee> employeeList = domainModel.GetAllTeachers();
            return Json(employeeList);
        }
    }
}