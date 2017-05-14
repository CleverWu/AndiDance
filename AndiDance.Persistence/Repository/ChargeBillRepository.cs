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
    public class ChargeBillRepository : BaseRepository<ChargeBill>
    {
        public ChargeBillRepository()
        {
            _dbTableName = "charge_bill";
            _fieldMap.Add("studioid", "StudioId");
            _fieldMap.Add("studioname", "StudioName");
            _fieldMap.Add("memberid", "MemberId");
            _fieldMap.Add("membername", "MemberName");
            _fieldMap.Add("payeeid", "PayeeId");
            _fieldMap.Add("payeename", "PayeeName");
            _fieldMap.Add("paymentmethod", "PaymentMethod");
            _fieldMap.Add("amount", "Amount");
            _fieldMap.Add("receiptnumber", "ReceiptNumber");
            _fieldMap.Add("time", "Time");
        }

        /// <summary>
        /// 通过时间和会员姓名搜索充值账单
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public List<ChargeBill> Search(string startTime, string endTime, string memberName)
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
                var query = _db.Query<ChargeBill>(sql, new { startTime, endTime, memberName });
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
