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
    public class ActivityRepository : BaseRepository<Activity>
    {
        public ActivityRepository()
        {
            _dbTableName = "activity";
            _fieldMap.Add("name", "Name");
            _fieldMap.Add("studioid", "StudioId");
            _fieldMap.Add("studioname", "StudioName");
            _fieldMap.Add("starttime", "StartTime");
            _fieldMap.Add("endtime", "EndTime");
            _fieldMap.Add("description", "Description");
        }

        /// <summary>
        /// 通过名称搜索活动
        /// </summary>
        /// <param name="name">活动名称</param>
        /// <returns></returns>
        public List<Activity> Search(string name)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"select * from {0} where name like '%@name%'", _dbTableName);
                var query = _db.Query<Activity>(sql, new { name });
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
