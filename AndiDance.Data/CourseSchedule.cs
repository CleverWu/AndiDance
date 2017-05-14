using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Data
{
    public class CourseSchedule : Entity
    {
        /// <summary>
        /// 所属门店
        /// </summary>
        public int StudioId { get; set; }
        /// <summary>
        /// 门店名
        /// </summary>
        public string StudioName { get; set; }
        /// <summary>
        /// 教室id
        /// </summary>
        public int ClassroomId { get; set; }
        /// <summary>
        /// 教室名称
        /// </summary>
        public string ClassroomName { get; set; }
        /// <summary>
        /// 课程
        /// </summary>
        public int CourseId { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// 教师
        /// </summary>
        public int TeacherId { get; set; }
        /// <summary>
        /// 教师名称
        /// </summary>
        public string TeacherName { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 星期几
        /// </summary>
        public string DayOfWeek { get; set; }
        /// <summary>
        /// 是否停课
        /// </summary>
        public bool IsSuspended { get; set; }
        /// <summary>
        /// 代课教师id
        /// </summary>
        public int SubTeacherId { get; set; }
        /// <summary>
        /// 代课教师姓名
        /// </summary>
        public string SubTeacherName { get; set; }
        /// <summary>
        /// 代课起始时间
        /// </summary>
        public DateTime SubStartTime { get; set; }
        /// <summary>
        /// 代课结束时间
        /// </summary>
        public DateTime SubEndTime { get; set; }
        /// <summary>
        /// 是否代课
        /// </summary>
        public bool IsSubstituted { get; set; }
    }
}
