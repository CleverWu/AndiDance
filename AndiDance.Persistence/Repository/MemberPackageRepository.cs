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
    public class MemberPackageRepository : BaseRepository<MemberPackage>
    {
        public MemberPackageRepository()
        {
            _dbTableName = "member_package";
            _fieldMap.Add("packageid", "PackageId");
            _fieldMap.Add("packagename", "PackageName");
            _fieldMap.Add("activityid", "ActivityId");
            _fieldMap.Add("activityname", "ActivityName");
            _fieldMap.Add("memberid", "MemberId");
            _fieldMap.Add("membername", "MemberName");
            _fieldMap.Add("studioid", "StudioId");
            _fieldMap.Add("studioname", "StudioName");
            _fieldMap.Add("price", "Price");
            _fieldMap.Add("hour", "Hour");
            _fieldMap.Add("duration", "Duration");
            _fieldMap.Add("remaininghour", "RemainingHour");
            _fieldMap.Add("starttime", "StartTime");
            _fieldMap.Add("endtime", "EndTime");
            _fieldMap.Add("freezestarttime", "FreezeStartTime");
            _fieldMap.Add("freezeendtime", "FreezeEndTime");
        }
        /// <summary>
        /// 获取或计算其他属性值
        /// </summary>
        /// <param name="entity"></param>
        protected override void GetOtherProperty(MemberPackage memberPackage)
        {
            //计算是否冻结中
            memberPackage.IsFrozen = false;
            if (memberPackage.FreezeStartTime != null && memberPackage.FreezeEndTime != null)
            {
                var dtNow = DateTime.Now;
                if (dtNow >= memberPackage.FreezeStartTime && dtNow <= memberPackage.FreezeEndTime)
                {
                    memberPackage.IsFrozen = true;
                }
            }
        }
        /// <summary>
        /// 获取会员已拥有的所有套餐
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<MemberPackage> GetAllMemberPackages(int memberId)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"select * from {0} where memberid=@memberId", _dbTableName);
                var query = _db.Query<MemberPackage>(sql, new { memberId });
                var result = query.ToList();
                foreach (var memberPackage in result)
                {
                    GetOtherProperty(memberPackage);
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 延长会员的套餐期限
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newEndTime"></param>
        public void ProlongMemberPackage(int id, DateTime newEndTime)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"update {0} set endtime=@newEndTime where id=@id", _dbTableName);
                var query = _db.Execute(sql, new { id, newEndTime });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取会员已拥有的可扣课的套餐
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<MemberPackage> GetAllDeductableMemberPackages(int memberId)
        {
            try
            {
                if (_db.State == ConnectionState.Closed)
                {
                    _db.Open();
                }
                var sql = string.Format(@"select * from {0} where memberid=@memberId and remaininghour>0 order by endtime", _dbTableName);
                var query = _db.Query<MemberPackage>(sql, new { memberId });
                var result = query.ToList();
                foreach (var memberPackage in result)
                {
                    GetOtherProperty(memberPackage);
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
