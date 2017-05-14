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
    public class EmployeeRepository : BaseRepository<Employee>
    {
        public EmployeeRepository()
        {
            _dbTableName = "employee";
            _fieldMap.Add("name", "Name");
            _fieldMap.Add("gender", "Gender");
            _fieldMap.Add("phone", "Phone");
            _fieldMap.Add("position", "Position");
            _fieldMap.Add("studioid", "StudioId");
            _fieldMap.Add("studioname", "StudioName");
            _fieldMap.Add("address", "Address");
            _fieldMap.Add("account", "Account");
            _fieldMap.Add("password", "Password");
            _fieldMap.Add("isteacher", "IsTeacher");
            _fieldMap.Add("jobstatus", "JobStatus");
            _fieldMap.Add("remarks", "Remarks");
            _fieldMap.Add("isdismissed", "IsDismissed");
            _fieldMap.Add("dismissionreason", "DismissionReason");
            _fieldMap.Add("isdeleted", "IsDeleted");
        }

        /// <summary>
        /// 通过姓名等条件搜索员工
        /// </summary>
        /// <param name="jobStatus">任职情况（在职，离职）</param>
        /// <param name="position">职位</param>
        /// <param name="name">员工名</param>
        /// <returns></returns>
        public List<Employee> Search(string jobStatus, string position, string name)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"select * from {0} where 1=1{1}{2}{3}{4}", _dbTableName,
                    string.IsNullOrEmpty(jobStatus) ? "" : " and jobstatus='@jobStatus'", string.IsNullOrEmpty(position) ? "" : " and position='@position'",
                    string.IsNullOrEmpty(name) ? "" : " and name like '%@name%'",
                    _includeDeleted ? "" : " and isdeleted=false");
                var query = _db.Query<Employee>(sql, new { jobStatus, position, name });
                var result = query.ToList();
                foreach (var employee in result)
                {
                    GetOtherProperty(employee);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 标记删除员工
        /// </summary>
        /// <param name="id">员工id</param>
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
        /// 员工离职
        /// </summary>
        /// <param name="id">员工id</param>
        /// <param name="dismissionReason">离职原因</param>
        public void DismissEmployee(int id, string dismissionReason)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"update {0} set isdeleted=true,isdismissed=true,dismissionreason=@dismissionReason where id=@id", _dbTableName);
                var query = _db.Execute(sql, new { id, dismissionReason });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取所有教师列表
        /// </summary>
        /// <returns></returns>
        public List<Employee> GetAllTeachers()
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"select * from {0} where isteacher=true{1}", _dbTableName, _includeDeleted ? "" : " and isdeleted=false");
                var query = _db.Query<Employee>(sql);
                var result = query.ToList();
                foreach (var employee in result)
                {
                    GetOtherProperty(employee);
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
