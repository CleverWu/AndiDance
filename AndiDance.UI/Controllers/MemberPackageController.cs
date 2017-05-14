using AndiDance.Data;
using AndiDance.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndiDance.UI.Controllers
{
    public class MemberPackageController : Controller
    {
        private MemberPackageDomainModel domainModel = new MemberPackageDomainModel();

        /// <summary>
        /// 获取会员已拥有的所有套餐
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public JsonResult GetAllMemberPackages(int memberId)
        {
            List<MemberPackage> memberPackageList = domainModel.GetAllMemberPackages(memberId);
            return Json(memberPackageList);
        }
        /// <summary>
        /// 获取会员已拥有的套餐详情
        /// </summary>
        /// <param name="memberPackageId"></param>
        /// <returns></returns>
        public JsonResult GetMemberPackageDetail(int memberPackageId)
        {
            MemberPackage memberPackage = domainModel.GetMemberPackageDetail(memberPackageId);
            return Json(memberPackage);
        }
        /// <summary>
        /// 延长会员的套餐期限
        /// </summary>
        /// <param name="memberPackageId"></param>
        /// <param name="newEndTime"></param>
        /// <returns></returns>
        public bool ProlongMemberPackage(int memberPackageId, string newEndTime)
        {
            return domainModel.ProlongMemberPackage(memberPackageId, newEndTime);
        }
        /// <summary>
        /// 退还套餐课时为余额
        /// </summary>
        /// <param name="memberPackageId">会员id</param>
        /// <param name="amountOfMoney">退还金额</param>
        /// <returns></returns>
        public bool RefundMemberPackage(int memberPackageId, double amountOfMoney)
        {
            return domainModel.RefundMemberPackage(memberPackageId, amountOfMoney);
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
            return domainModel.FreezeMemberPackage(memberPackageId, startTime, endTime);
        }
        /// <summary>
        /// 恢复使用套餐
        /// </summary>
        /// <param name="memberPackageId"></param>
        /// <returns></returns>
        public bool ResumeMemberPackage(int memberPackageId)
        {
            return domainModel.ResumeMemberPackage(memberPackageId);
        }
        /// <summary>
        /// 获取套餐操作记录
        /// </summary>
        /// <param name="memberPackageId"></param>
        /// <returns></returns>
        public JsonResult GetMemberPackageActionRecord(int memberPackageId)
        {
            List<ActionRecord> actionRecordList = domainModel.GetMemberPackageActionRecord(memberPackageId);
            return Json(actionRecordList);
        }
    }
}