using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndiDance.Data;
using AndiDance.Persistence.RepositoryService;

namespace AndiDance.DomainModel
{
    public class EmployeeDomainModel
    {
        private EmployeeRepositoryService repositoryService = new EmployeeRepositoryService();

        /// <summary>
        /// 获取相关员工列表数据
        /// </summary>
        /// <param name="jobStatus">任职情况（在职，离职）</param>
        /// <param name="position">职位</param>
        /// <param name="employeeName">员工名</param>
        /// <returns></returns>
        public List<Employee> GetAllEmployees(string jobStatus, string position, string employeeName)
        {
            return repositoryService.GetAllEmployees(jobStatus, position, employeeName);
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool AddEmployee(Employee employee)
        {
            return repositoryService.AddEmployee(employee);
        }
        /// <summary>
        /// 获取员工详情
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public Employee GetEmployeeDetail(int employeeId)
        {
            return repositoryService.GetEmployeeDetail(employeeId);
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public bool DeleteEmployee(int employeeId)
        {
            return repositoryService.DeleteEmployee(employeeId);
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
            var result = false;
            if (!string.IsNullOrEmpty(startTime) && !string.IsNullOrEmpty(endTime))
            {
                var dtStartTime = Convert.ToDateTime(startTime);
                var dtEndTime = Convert.ToDateTime(endTime);
                result = repositoryService.SubstituteCourseSchedule(courseScheduleId, subEmployeeId, dtStartTime, dtEndTime);
            }
            return result;
        }
        /// <summary>
        /// 停课
        /// </summary>
        /// <param name="courseScheduleId">课程id</param>
        /// <returns></returns>
        public bool SuspendCourseSchedule(int courseScheduleId)
        {
            return repositoryService.SuspendCourseSchedule(courseScheduleId);
        }
        /// <summary>
        /// 恢复上课
        /// </summary>
        /// <param name="courseScheduleId">课程id</param>
        /// <returns></returns>
        public bool ResumeCourseSchedule(int courseScheduleId)
        {
            return repositoryService.ResumeCourseSchedule(courseScheduleId);
        }
        /// <summary>
        /// 员工离职
        /// </summary>
        /// <param name="employeeId">员工id</param>
        /// <param name="dismissionReason">离职原因</param>
        /// <returns></returns>
        public bool DismissEmployee(int employeeId, string dismissionReason)
        {
            return repositoryService.DismissEmployee(employeeId, dismissionReason);
        }
        /// <summary>
        /// 获取所有教师列表
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllTeachers()
        {
            return repositoryService.GetAllTeachers();
        }
    }
}
