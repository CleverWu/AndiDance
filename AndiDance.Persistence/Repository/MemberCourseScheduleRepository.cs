using AndiDance.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Persistence.Repository
{
    public class MemberCourseScheduleRepository : BaseRepository<MemberCourseSchedule>
    {
        public MemberCourseScheduleRepository()
        {
            _dbTableName = "member_course_schedule";
            _fieldMap.Add("memberid", "MemberId");
            _fieldMap.Add("membername", "MemberName");
            _fieldMap.Add("coursescheduleid", "CourseScheduleId");
            _fieldMap.Add("classroomid", "ClassroomId");
            _fieldMap.Add("classroomname", "ClassroomName");
            _fieldMap.Add("courseid", "CourseId");
            _fieldMap.Add("coursename", "CourseName");
            _fieldMap.Add("teacherid", "TeacherId");
            _fieldMap.Add("teachername", "TeacherName");
            _fieldMap.Add("starttime", "StartTime");
            _fieldMap.Add("endtime", "EndTime");
            _fieldMap.Add("dayofweek", "DayOfWeek");
        }

        /// <summary>
        /// 清除会员已选课程
        /// </summary>
        /// <param name="memberId"></param>
        public void CleanByMemberId(int memberId)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"delete from {0} where memberid=@memberId", _dbTableName);
                var query = _db.Execute(sql, new { memberId });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
