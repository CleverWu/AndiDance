using AndiDance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace AndiDance.Persistence.Repository
{
    public class CourseScheduleRepository : BaseRepository<CourseSchedule>
    {
        public CourseScheduleRepository()
        {
            _dbTableName = "course_schedule";
            _fieldMap.Add("studioid", "StudioId");
            _fieldMap.Add("studioname", "StudioName");
            _fieldMap.Add("classroomid", "ClassroomId");
            _fieldMap.Add("classroomname", "ClassroomName");
            _fieldMap.Add("courseid", "CourseId");
            _fieldMap.Add("coursename", "CourseName");
            _fieldMap.Add("teacherid", "TeacherId");
            _fieldMap.Add("teachername", "TeacherName");
            _fieldMap.Add("starttime", "StartTime");
            _fieldMap.Add("endtime", "EndTime");
            _fieldMap.Add("dayofweek", "DayOfWeek");
            _fieldMap.Add("issuspended", "IsSuspended");
            _fieldMap.Add("subteacherid", "SubTeacherId");
            _fieldMap.Add("subteachername", "SubTeacherName");
            _fieldMap.Add("substarttime", "SubStartTime");
            _fieldMap.Add("subendtime", "SubEndTime");
        }

        /// <summary>
        /// 获取或计算其他属性值
        /// </summary>
        /// <param name="courseSchedule"></param>
        protected override void GetOtherProperty(CourseSchedule courseSchedule)
        {
            //计算是否正在代课
            courseSchedule.IsSubstituted = false;
            if (courseSchedule.SubStartTime != null && courseSchedule.SubEndTime != null)
            {
                var dtNow = DateTime.Now;
                if (dtNow >= courseSchedule.SubStartTime && dtNow <= courseSchedule.SubEndTime)
                {
                    courseSchedule.IsSubstituted = true;
                }
            }
        }
        /// <summary>
        /// 代课
        /// </summary>
        /// <param name="id">课程id</param>
        /// <param name="subTeacherId">代课教师id</param>
        /// <param name="subTeacherName">代课教师姓名</param>
        /// <param name="subStartTime">代课起始时间</param>
        /// <param name="subEndTime">代课结束时间</param>
        public void SubstituteCourseSchedule(int id, int subTeacherId, string subTeacherName, DateTime subStartTime, DateTime subEndTime)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"update {0} set subteacherid=@subTeacherId,subteachername=@subTeacherName,
substarttime=@subStartTime,subendtime=@subEndTime where id=@id", _dbTableName);
                var query = _db.Execute(sql, new { id, subTeacherId, subTeacherName, subStartTime, subEndTime });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 停课
        /// </summary>
        /// <param name="id">课程id</param>
        public void SuspendCourseSchedule(int id)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"update {0} set issuspended=true where id=@id", _dbTableName);
                var query = _db.Execute(sql, new { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 恢复上课
        /// </summary>
        /// <param name="id">课程id</param>
        public void ResumeCourseSchedule(int id)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"update {0} set issuspended=false where id=@id", _dbTableName);
                var query = _db.Execute(sql, new { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
