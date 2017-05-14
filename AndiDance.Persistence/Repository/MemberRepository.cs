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
    public class MemberRepository : BaseRepository<Member>
    {
        public MemberRepository()
        {
            _dbTableName = "member";
            _fieldMap.Add("cardid", "CardId");
            _fieldMap.Add("name", "Name");
            _fieldMap.Add("gender", "Gender");
            _fieldMap.Add("type", "Type");
            _fieldMap.Add("qq", "QQ");
            _fieldMap.Add("phone", "Phone");
            _fieldMap.Add("birthday", "Birthday");
            _fieldMap.Add("age", "Age");
            _fieldMap.Add("regdate", "RegDate");
            _fieldMap.Add("studioid", "StudioId");
            _fieldMap.Add("studioname", "StudioName");
            _fieldMap.Add("transactorid", "TransactorId");
            _fieldMap.Add("transactorname", "TransactorName");
            _fieldMap.Add("coursecounselorid", "CourseCounselorId");
            _fieldMap.Add("coursecounselorname", "CourseCounselorName");
            _fieldMap.Add("balance", "Balance");
            _fieldMap.Add("currentpackageid", "CurrentPackageid");
            _fieldMap.Add("currentpackagename", "CurrentPackagename");
            _fieldMap.Add("lastcoursescheduleid", "LastCourseScheduleId");
            _fieldMap.Add("lastcoursename", "LastCourseName");
            _fieldMap.Add("lastcoursestarttime", "LastCourseStartTime");
            _fieldMap.Add("lastcourseendtime", "LastCourseEndTime");
            _fieldMap.Add("remarks", "Remarks");
            _fieldMap.Add("isdeleted", "IsDeleted");
        }

        /// <summary>
        /// 获取或计算其他属性值
        /// </summary>
        /// <param name="member"></param>
        protected override void GetOtherProperty(Member member)
        {
            //计算是否正在上课
            member.IsInClass = false;
            if (member.LastCourseStartTime != null && member.LastCourseEndTime != null)
            {
                var dtNow = DateTime.Now;
                if (dtNow >= member.LastCourseStartTime && dtNow <= member.LastCourseEndTime)
                {
                    member.IsInClass = true;
                }
            }
        }

        /// <summary>
        /// 通过姓名搜索会员
        /// </summary>
        /// <param name="name">会员姓名</param>
        /// <returns></returns>
        public List<Member> Search(string name)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"select * from {0} where name like '%@name%'{1}", _dbTableName,
                    _includeDeleted ? "" : " and isdeleted=false");
                var query = _db.Query<Member>(sql, new { name });
                var result = query.ToList();
                foreach (var member in result)
                {
                    GetOtherProperty(member);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 标记删除会员
        /// </summary>
        /// <param name="id">会员id</param>
        public void MarkDelete(int id)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"update {0} set isdeleted=true where id=@Id", _dbTableName);
                var query = _db.Execute(sql, new { id });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取门店会员数据
        /// </summary>
        /// <param name="studioId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Member> GetBranchStudioMembers(int studioId, string name)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"select * from {0} where studioid=@studioId{1}{2}", _dbTableName,
                    string.IsNullOrEmpty(name) ? "" : " and name like '%@name%'",
                    _includeDeleted ? "" : " and isdeleted=false");
                var query = _db.Query<Member>(sql, new { studioId, name });
                var result = query.ToList();
                foreach (var member in result)
                {
                    GetOtherProperty(member);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
