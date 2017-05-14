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
    public class PackageBillRepository : BaseRepository<PackageBill>
    {
        public PackageBillRepository()
        {
            _dbTableName = "package_bill";
            _fieldMap.Add("studioid", "StudioId");
            _fieldMap.Add("studioname", "StudioName");
            _fieldMap.Add("memberid", "MemberId");
            _fieldMap.Add("membername", "MemberName");
            _fieldMap.Add("transactorid", "TransactorId");
            _fieldMap.Add("transactorname", "TransactorName");
            _fieldMap.Add("memberpackageid", "MemberPackageId");
            _fieldMap.Add("packagename", "PackageName");
            _fieldMap.Add("activityid", "ActivityId");
            _fieldMap.Add("activityname", "ActivityName");
            _fieldMap.Add("price", "Price");
            _fieldMap.Add("hour", "Hour");
            _fieldMap.Add("time", "Time");
        }

        /// <summary>
        /// 获取所有套餐账单列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public List<PackageBill> GetAllPackageBills(string startTime, string endTime, string memberName)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"select * from {0} where 1=1{2}{2}{3} ", _dbTableName,
                    string.IsNullOrEmpty(startTime) ? "" : " and time>=@startTime", string.IsNullOrEmpty(endTime) ? "" : " and time<=@endTime",
                    string.IsNullOrEmpty(memberName) ? "" : " and name like '%@memberName%'");
                var query = _db.Query<PackageBill>(sql, new { startTime, endTime, memberName });
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
