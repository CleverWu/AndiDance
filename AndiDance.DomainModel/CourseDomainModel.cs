using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndiDance.Data;
using AndiDance.Persistence.RepositoryService;

namespace AndiDance.DomainModel
{
    public class CourseDomainModel
    {
        private CourseRepositoryService repositoryService = new CourseRepositoryService();

        /// <summary>
        /// 获取所有课程列表
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public List<Course> GetAllCourses(string courseName)
        {
            return repositoryService.GetAllCourses(courseName);
        }
        /// <summary>
        /// 添加课程
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public bool AddCourse(Course course)
        {
            return repositoryService.AddCourse(course);
        }
        /// <summary>
        /// 获取课程信息
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Course GetCourseDetail(int courseId)
        {
            return repositoryService.GetCourseDetail(courseId);
        }
    }
}
