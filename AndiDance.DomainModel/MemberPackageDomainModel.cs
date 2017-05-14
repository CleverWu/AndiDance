using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndiDance.Data;
using AndiDance.Persistence.RepositoryService;

namespace AndiDance.DomainModel
{
    public class MemberPackageDomainModel
    {
        private MemberPackageRepositoryService repositoryService = new MemberPackageRepositoryService();

        /// <summary>
        /// 获取会员已拥有的所有套餐
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<MemberPackage> GetAllMemberPackages(int memberId)
        {
            return repositoryService.GetAllMemberPackages(memberId);
        }
        /// <summary>
        /// 获取会员已拥有的套餐详情
        /// </summary>
        /// <param name="memberPackageId"></param>
        /// <returns></returns>
        public MemberPackage GetMemberPackageDetail(int memberPackageId)
        {
            return repositoryService.GetMemberPackageDetail(memberPackageId);
        }
        /// <summary>
        /// 延长会员的套餐期限
        /// </summary>
        /// <param name="memberPackageId"></param>
        /// <param name="newEndTime"></param>
        /// <returns></returns>
        public bool ProlongMemberPackage(int memberPackageId, string newEndTime)
        {
            var result = false;
            if (!string.IsNullOrEmpty(newEndTime))
            {
                var dtNewEndTime = Convert.ToDateTime(newEndTime);
                result = repositoryService.ProlongMemberPackage(memberPackageId, dtNewEndTime);
            }
            return result;
        }
        /// <summary>
        /// 退还套餐课时为余额
        /// </summary>
        /// <param name="memberPackageId">会员id</param>
        /// <param name="amountOfMoney">退还金额</param>
        /// <returns></returns>
        public bool RefundMemberPackage(int memberPackageId, double amountOfMoney)
        {
            return repositoryService.RefundMemberPackage(memberPackageId, amountOfMoney);
        }
        /// <summary>
        /// 冻结套餐
        /// </summary>
        /// <param name="memberPackageId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public bool FreezeMemberPackage(int memberPackageId, string startTime, string endTime)
        {
            var result = false;
            if (!string.IsNullOrEmpty(startTime)&&!string.IsNullOrEmpty(endTime))
            {
                var dtStartTime = Convert.ToDateTime(startTime);
                var dtEndTime = Convert.ToDateTime(endTime);
                result = repositoryService.FreezeMemberPackage(memberPackageId, dtStartTime, dtEndTime);
            }
            return result;
        }
        /// <summary>
        /// 恢复使用套餐
        /// </summary>
        /// <param name="memberPackageId"></param>
        /// <returns></returns>
        public bool ResumeMemberPackage(int memberPackageId)
        {
            return repositoryService.ResumeMemberPackage(memberPackageId);
        }
        /// <summary>
        /// 获取套餐操作记录
        /// </summary>
        /// <param name="memberPackageId"></param>
        /// <returns></returns>
        public List<ActionRecord> GetMemberPackageActionRecord(int memberPackageId)
        {
            return repositoryService.GetMemberPackageActionRecord(memberPackageId);
        }
    }
}
