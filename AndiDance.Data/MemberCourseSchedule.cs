using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Data
{
    public class MemberCourseSchedule : Entity
    {
        /// <summary>
        /// 会员编号
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 课程安排编号
        /// </summary>
        public int CourseScheduleId { get; set; }
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
    }
}
