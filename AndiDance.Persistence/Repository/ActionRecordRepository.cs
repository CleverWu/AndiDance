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
    public class ActionRecordRepository : BaseRepository<ActionRecord>
    {
        public ActionRecordRepository()
        {
            _dbTableName = "action_record";
            _fieldMap.Add("actorid", "ActorId");
            _fieldMap.Add("actorname", "ActorName");
            _fieldMap.Add("objecttype", "ObjectType");
            _fieldMap.Add("objectid", "ObjectId");
            _fieldMap.Add("objectname", "ObjectName");
            _fieldMap.Add("action", "Action");
            _fieldMap.Add("time", "Time");
        }
        /// <summary>
        /// 通过操作对象类型和id获取操作记录
        /// </summary>
        /// <param name="objectType"></param>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public List<ActionRecord> GetByObject(string objectType, int objectId)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"select * from {0} where objecttype=@objectType and objectid=@objectId", _dbTableName);
                var query = _db.Query<ActionRecord>(sql, new { objectType, objectId });
                var result = query.ToList();
                foreach (var ActionRecord in result)
                {
                    GetOtherProperty(ActionRecord);
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
