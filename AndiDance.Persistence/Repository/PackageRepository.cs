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
    public class PackageRepository : BaseRepository<Package>
    {
        public PackageRepository()
        {
            _dbTableName = "package";
            _fieldMap.Add("name", "Name");
            _fieldMap.Add("studioid", "StudioId");
            _fieldMap.Add("studioname", "StudioName");
            _fieldMap.Add("price", "Price");
            _fieldMap.Add("hour", "Hour");
            _fieldMap.Add("duration", "Duration");
            _fieldMap.Add("consumptionmode", "ConsumptionMode");
            _fieldMap.Add("minconsumptionunit", "MinConsumptionUnit");
            _fieldMap.Add("minconsumptionhour", "MinConsumptionHour");
            _fieldMap.Add("description", "Description");
            _fieldMap.Add("activityid", "ActivityId");
            _fieldMap.Add("activityname", "ActivityName");
            _fieldMap.Add("activityprice", "ActivityPrice");
            _fieldMap.Add("activityhour", "ActivityHour");
            _fieldMap.Add("activityduration", "ActivityDuration");
            _fieldMap.Add("isavailable", "IsAvailable");
        }

        /// <summary>
        /// 通过套餐名称搜索套餐
        /// </summary>
        /// <param name="name">套餐名称</param>
        /// <returns></returns>
        public List<Package> Search(string name)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"select * from {0}{1}", _dbTableName,
                    string.IsNullOrEmpty(name) ? "" : " where name like '%@name%'");
                var query = _db.Query<Package>(sql, new { name });
                var result = query.ToList();
                foreach (var package in result)
                {
                    GetOtherProperty(package);
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
