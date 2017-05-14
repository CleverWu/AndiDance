using AndiDance.Data;
using AndiDance.Persistence.RepositoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.DomainModel
{
    public class MemberDomainModel
    {
        private MemberRepositoryService repositoryService = new MemberRepositoryService();

        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public bool AddMember(Member member)
        {
            return repositoryService.AddMember(member);
        }
        /// <summary>
        /// 绑定会员卡
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public bool BindMembershipCard(int memberId, string cardId)
        {
            return repositoryService.BindMembershipCard(memberId, cardId);
        }
        /// <summary>
        /// 获取会员详情
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public Member GetMemberDetail(int memberId)
        {
            return repositoryService.GetMemberDetail(memberId);
        }
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
            return repositoryService.ChargeMemberStorevalue(memberId, payeeId, paymentMethod, amount, receiptNumber);
        }
        /// <summary>
        /// 搜索会员
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public List<Member> SearchMember(string memberName)
        {
            return repositoryService.SearchMember(memberName);
        }
        /// <summary>
        /// 会员扣课
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public bool DeductMemberCourse(int memberId, int courseId)
        {
            return repositoryService.DeductMemberCourse(memberId, courseId);
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
            return repositoryService.BuyPackage(memberId, employeeId, packageId, packagePrice, packageHour, packageDuration);
        }
        /// <summary>
        /// 会员选课
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="listCourseScheduleId"></param>
        /// <returns></returns>
        public bool SelectCourses(int memberId, List<int> listCourseScheduleId)
        {
            return repositoryService.SelectCourses(memberId, listCourseScheduleId);
        }
        /// <summary>
        /// 补卡
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public bool ReissueMembershipCard(int memberId, string cardId)
        {
            return repositoryService.ReissueMembershipCard(memberId, cardId);
        }
        /// <summary>
        /// 获取门店会员数据
        /// </summary>
        /// <param name="studioId"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public List<Member> GetBranchStudioMembers(int studioId, string memberName)
        {
            return repositoryService.GetBranchStudioMembers(studioId, memberName);
        }
    }
}
