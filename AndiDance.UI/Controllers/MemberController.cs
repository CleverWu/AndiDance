using AndiDance.Data;
using AndiDance.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndiDance.UI.Controllers
{
    public class MemberController : Controller
    {
        private MemberDomainModel domainModel = new MemberDomainModel();

        /// <summary>
        /// 今日新增会员相关数据
        /// </summary>
        /// <param name="studioId">分店编号</param>
        /// <param name="memberName">会员名</param>
        /// <returns></returns>
        public JsonResult GetNewMembersTodayData(string studioId, string memberName)
        {
            return null;
        }

        #region 会员添加
        /// <summary>
        /// 会员添加页面
        /// </summary>
        /// <returns></returns>
        public ActionResult MemberAddingView()
        {
            return View();
        }
        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public bool AddMember(Member member)
        {
            return domainModel.AddMember(member);
        }
        /// <summary>
        /// 绑定会员卡
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public bool BindMembershipCard(int memberId, string cardId)
        {
            return domainModel.BindMembershipCard(memberId, cardId);
        }
        #endregion

        #region 会员信息
        /// <summary>
        /// 会员详情页面
        /// </summary>
        /// <returns></returns>
        public ActionResult MemberDetailView()
        {
            return View();
        }
        /// <summary>
        /// 获取会员详情
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public JsonResult GetMemberDetail(int memberId)
        {
            Member member = domainModel.GetMemberDetail(memberId);
            return Json(member);
        }
        #endregion

        #region 会员操作
        /// <summary>
        /// 会员充值
        /// </summary>
        /// <param name="memberId">会员id</param>
        /// <param name="payeeId">收款人</param>
        /// <param name="paymentMethod">付款方式</param>
        /// <param name="amount">金额</param>
        /// <param name="receiptNumber">收款单据号</param>
        /// <returns></returns>
        public bool ChargeMemberStorevalue(int memberId, int payeeId, string paymentMethod, double amount, string receiptNumber)
        {
            return domainModel.ChargeMemberStorevalue(memberId, payeeId, paymentMethod, amount, receiptNumber);
        }
        /// <summary>
        /// 搜索会员
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public JsonResult SearchMember(string memberName)
        {
            List<Member> memberList = domainModel.SearchMember(memberName);
            return Json(memberList);
        }
        /// <summary>
        /// 会员扣课
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public bool DeductMemberCourse(int memberId, int courseId)
        {
            return domainModel.DeductMemberCourse(memberId, courseId);
        }
        /// <summary>
        /// 购买套餐
        /// </summary>
        /// <param name="memberId">会员id</param>
        /// <param name="employeeId">员工id</param>
        /// <param name="packageId">套餐id</param>
        /// <param name="packagePrice">套餐价格</param>
        /// <param name="packageHour">套餐课时</param>
        /// <param name="packageDuration">套餐有效时限</param>
        /// <returns></returns>
        public bool BuyPackage(int memberId, int employeeId, int packageId, double packagePrice, int packageHour, int packageDuration)
        {
            return domainModel.BuyPackage(memberId, employeeId, packageId, packagePrice, packageHour, packageDuration);
        }
        /// <summary>
        /// 会员选课
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="listCourseScheduleId"></param>
        /// <returns></returns>
        public bool SelectCourses(int memberId, List<int> listCourseScheduleId)
        {
            return domainModel.SelectCourses(memberId, listCourseScheduleId);
        }
        /// <summary>
        /// 补卡
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public bool ReissueMembershipCard(int memberId, string cardId)
        {
            return domainModel.ReissueMembershipCard(memberId, cardId);
        }
        #endregion

        #region 门店会员
        /// <summary>
        /// 门店会员页面
        /// </summary>
        /// <returns></returns>
        public ActionResult BranchStudioMembersView()
        {
            return View();
        }
        /// <summary>
        /// 获取门店会员数据
        /// </summary>
        /// <param name="studioId"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public JsonResult GetBranchStudioMembers(int studioId, string memberName)
        {
            List<Member> memberList = domainModel.GetBranchStudioMembers(studioId, memberName);
            return Json(memberList);
        }
        #endregion
    }
}