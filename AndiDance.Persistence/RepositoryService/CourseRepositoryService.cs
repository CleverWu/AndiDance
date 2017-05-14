using AndiDance.Data;
using AndiDance.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Persistence.RepositoryService
{
    public class CourseRepositoryService : BaseRepositoryService
    {
        private CourseRepository repository = new CourseRepository();

        /// <summary>
        /// 获取所有课程列表
        /// </summary>
        /// <param name="courseName"></param>
        /// <returns></returns>
        public List<Course> GetAllCourses(string courseName)
        {
            if (string.IsNullOrEmpty(courseName))
            {
                return repository.GetAll();
            }
            else
            {
                return repository.Search(courseName);
            }
        }
        /// <summary>
        /// 添加课程
        /// </summary>
        /// <param name="course"></param>
        /// <returns></returns>
        public bool AddCourse(Course course)
        {
            repository.Add(course);
            return true;
        }
        /// <summary>
        /// 获取课程信息
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public Course GetCourseDetail(int courseId)
        {
            return repository.GetById(courseId);
        }
    }
}
