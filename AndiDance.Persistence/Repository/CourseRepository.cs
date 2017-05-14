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
    public class CourseRepository : BaseRepository<Course>
    {
        public CourseRepository()
        {
            _dbTableName = "course";
            _fieldMap.Add("name", "Name");
            _fieldMap.Add("costhour", "CostHour");
            _fieldMap.Add("dancetype", "DanceType");
            _fieldMap.Add("classtype", "ClassType");
            _fieldMap.Add("coursetype", "CourseType");
            _fieldMap.Add("studioid", "StudioId");
            _fieldMap.Add("studioname", "StudioName");
            _fieldMap.Add("description", "Description");
        }

        /// <summary>
        /// 通过名称搜索课程
        /// </summary>
        /// <param name="name">课程名称</param>
        /// <returns></returns>
        public List<Course> Search(string name)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"select * from {0} where name like '%@name%'", _dbTableName);
                var query = _db.Query<Course>(sql, new { name });
                var result = query.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
