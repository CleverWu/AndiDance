using AndiDance.Data;
using AndiDance.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Persistence.RepositoryService
{
    public class MemberPackageRepositoryService : BaseRepositoryService
    {
        private MemberPackageRepository repository = new MemberPackageRepository();
        private MemberRepository memberRepository = new MemberRepository();
        private ActionRecordRepository actionRecordRepository = new ActionRecordRepository();

        /// <summary>
        /// 获取会员已拥有的所有套餐
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public List<MemberPackage> GetAllMemberPackages(int memberId)
        {
            return repository.GetAllMemberPackages(memberId);
        }
        /// <summary>
        /// 获取会员已拥有的套餐详情
        /// </summary>
        /// <param name="memberPackageId"></param>
        /// <returns></returns>
        public MemberPackage GetMemberPackageDetail(int memberPackageId)
        {
            return repository.GetById(memberPackageId);
        }
        /// <summary>
        /// 延长会员的套餐期限
        /// </summary>
        /// <param name="memberPackageId"></param>
        /// <param name="newEndTime"></param>
        /// <returns></returns>
        public bool ProlongMemberPackage(int memberPackageId, DateTime newEndTime)
        {
            repository.ProlongMemberPackage(memberPackageId, newEndTime);
            return true;
        }
        /// <summary>
        /// 退还套餐课时为余额
        /// </summary>
        /// <param name="memberPackageId">会员id</param>
        /// <param name="amountOfMoney">退还金额</param>
        /// <returns></returns>
        public bool RefundMemberPackage(int memberPackageId, double amountOfMoney)
        {
            var memberPackage = repository.GetById(memberPackageId);
            var member = memberRepository.GetById(memberPackage.MemberId);
            //退换金额到账户余额
            member.Balance += amountOfMoney;
            //剩余课时设为0
            memberPackage.RemainingHour = 0;
            //更新
            memberRepository.Update(member);
            repository.Update(memberPackage);
            return true;
        }
        /// <summary>
        /// 冻结套餐
        /// </summary>
        /// <param name="memberPackageId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public bool FreezeMemberPackage(int memberPackageId, DateTime startTime, DateTime endTime)
        {
            //计算冻结持续时间
            var freezeDuration = endTime - startTime;
            var memberPackage = repository.GetById(memberPackageId);
            //更新套餐结束时间
            memberPackage.EndTime += freezeDuration;
            memberPackage.FreezeStartTime = startTime;
            memberPackage.FreezeEndTime = endTime;

            repository.Update(memberPackage);
            return true;
        }
        /// <summary>
        /// 恢复使用套餐
        /// </summary>
        /// <param name="memberPackageId"></param>
        /// <returns></returns>
        public bool ResumeMemberPackage(int memberPackageId)
        {
            var memberPackage = repository.GetById(memberPackageId);
            //设定冻结结束时间为当前时间
            if (memberPackage.IsFrozen)
            {
                memberPackage.FreezeEndTime = DateTime.Now;
            }
            repository.Update(memberPackage);

            //设为使用中
            var member = memberRepository.GetById(memberPackage.MemberId);
            member.CurrentPackageid = memberPackageId;
            member.CurrentPackagename = memberPackage.PackageName;

            memberRepository.Update(member);
            return true;
        }
        /// <summary>
        /// 获取套餐操作记录
        /// </summary>
        /// <param name="memberPackageId"></param>
        /// <returns></returns>
        public List<ActionRecord> GetMemberPackageActionRecord(int memberPackageId)
        {
            return actionRecordRepository.GetByObject("MemberPackage", memberPackageId);
        }
    }
}
