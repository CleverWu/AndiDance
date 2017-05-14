using AndiDance.Data;
using AndiDance.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Persistence.RepositoryService
{
    public class EmployeeRepositoryService : BaseRepositoryService
    {
        private EmployeeRepository repository = new EmployeeRepository();
        private CourseScheduleRepository courseScheduleRepository = new CourseScheduleRepository();

        /// <summary>
        /// 获取相关员工列表数据
        /// </summary>
        /// <param name="jobStatus">任职情况（在职，离职）</param>
        /// <param name="position">职位</param>
        /// <param name="employeeName">员工名</param>
        /// <returns></returns>
        public List<Employee> GetAllEmployees(string jobStatus, string position, string employeeName)
        {
            return repository.Search(jobStatus, position, employeeName);
        }
        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool AddEmployee(Employee employee)
        {
            repository.Add(employee);
            return true;
        }
        /// <summary>
        /// 获取员工详情
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public Employee GetEmployeeDetail(int employeeId)
        {
            return repository.GetById(employeeId);
        }
        /// <summary>
        /// 删除员工
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public bool DeleteEmployee(int employeeId)
        {
            repository.MarkDelete(employeeId);
            return true;
        }
        /// <summary>
        /// 代课
        /// </summary>
        /// <param name="subEmployeeId">课程id</param>
        /// <param name="subEmployeeId">代课员工id</param>
        /// <param name="startTime">起始时间</param>
        /// <param name="endTime">结束时间</param>
        /// <returns></returns>
        public bool SubstituteCourseSchedule(int courseScheduleId, int subEmployeeId, DateTime startTime, DateTime endTime)
        {
            var teacher = repository.GetById(subEmployeeId);
            courseScheduleRepository.SubstituteCourseSchedule(courseScheduleId, subEmployeeId, teacher.Name, startTime, endTime);
            return true;
        }
        /// <summary>
        /// 停课
        /// </summary>
        /// <param name="courseScheduleId">课程id</param>
        /// <returns></returns>
        public bool SuspendCourseSchedule(int courseScheduleId)
        {
            courseScheduleRepository.SuspendCourseSchedule(courseScheduleId);
            return true;
        }
        /// <summary>
        /// 恢复上课
        /// </summary>
        /// <param name="courseScheduleId">课程id</param>
        /// <returns></returns>
        public bool ResumeCourseSchedule(int courseScheduleId)
        {
            courseScheduleRepository.ResumeCourseSchedule(courseScheduleId);
            return true;
        }
        /// <summary>
        /// 员工离职
        /// </summary>
        /// <param name="employeeId">员工id</param>
        /// <param name="dismissionReason">离职原因</param>
        /// <returns></returns>
        public bool DismissEmployee(int employeeId, string dismissionReason)
        {
            repository.DismissEmployee(employeeId, dismissionReason);
            return true;
        }
        /// <summary>
        /// 获取所有教师列表
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllTeachers()
        {
            return repository.GetAllTeachers();
        }
    }
}
