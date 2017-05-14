using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndiDance.Data;
using AndiDance.Persistence.Repository;

namespace AndiDance.Persistence.RepositoryService
{
    public class MemberRepositoryService : BaseRepositoryService
    {
        private MemberRepository repository = new MemberRepository();
        private ChargeBillRepository chargeBillRepository = new ChargeBillRepository();
        private EmployeeRepository employeeRepository = new EmployeeRepository();
        private CourseRepository courseRepository = new CourseRepository();
        private MemberPackageRepository memberPackageRepository = new MemberPackageRepository();
        private PackageRepository packageRepository = new PackageRepository();
        private PackageBillRepository packageBillRepository = new PackageBillRepository();
        private CourseScheduleRepository courseScheduleRepository = new CourseScheduleRepository();
        private MemberCourseScheduleRepository memberCourseScheduleRepository = new MemberCourseScheduleRepository();

        /// <summary>
        /// 添加会员
        /// </summary>
        /// <param name="member"></param>
        /// <returns></returns>
        public bool AddMember(Member member)
        {
            repository.Add(member);
            return true;
        }
        /// <summary>
        /// 绑定会员卡
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public bool BindMembershipCard(int memberId, string cardId)
        {
            var member = repository.GetById(memberId);
            member.CardId = cardId;
            repository.Update(member);
            return true;
        }
        /// <summary>
        /// 获取会员详情
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public Member GetMemberDetail(int memberId)
        {
            return repository.GetById(memberId);
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
            //更新会员
            var member = repository.GetById(memberId);
            member.Balance += amount;
            repository.Update(member);

            //新增充值账单信息
            var payee = employeeRepository.GetById(payeeId);
            var chargeBill = new ChargeBill
            {
                MemberId = memberId,
                MemberName = member.Name,
                PayeeId = payeeId,
                PayeeName = payee.Name,
                PaymentMethod = paymentMethod,
                Amount = amount,
                ReceiptNumber = receiptNumber,
                StudioId = member.StudioId,
                StudioName = member.StudioName,
                Time = DateTime.Now
            };
            chargeBillRepository.Add(chargeBill);
            return true;
        }
        /// <summary>
        /// 搜索会员
        /// </summary>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public List<Member> SearchMember(string memberName)
        {
            return repository.Search(memberName);
        }
        /// <summary>
        /// 会员扣课
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="courseId"></param>
        /// <returns></returns>
        public bool DeductMemberCourse(int memberId, int courseId)
        {
            var member = repository.GetById(memberId);
            var course = courseRepository.GetById(courseId);
            //递归扣除课时
            DeductCourseHourRecursively(memberId, course.CostHour);

            return true;
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
            var member = repository.GetById(memberId);
            var package = packageRepository.GetById(packageId);
            var transactor = employeeRepository.GetById(employeeId);
            //新增会员套餐
            var memberPackage = new MemberPackage
            {
                PackageId = package.Id,
                PackageName = package.Name,
                ActivityId = package.ActivityId,
                ActivityName = package.ActivityName,
                MemberId = member.Id,
                MemberName = member.Name,
                StudioId = member.StudioId,
                StudioName = member.StudioName,
                Price = packagePrice,
                Hour = packageHour,
                Duration = packageDuration,
                RemainingHour = packageHour,
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddDays(packageDuration)
            };
            memberPackageRepository.Add(memberPackage);

            //新增套餐账单
            var packageBill = new PackageBill
            {
                StudioId = member.StudioId,
                StudioName = member.StudioName,
                MemberId = member.Id,
                MemberName = member.Name,
                TransactorId = transactor.Id,
                TransactorName = transactor.Name,
                MemberPackageId = memberPackage.Id,
                PackageName = package.Name,
                ActivityId = package.ActivityId,
                ActivityName = package.ActivityName,
                Price = memberPackage.Price,
                Hour = memberPackage.Hour,
                Time = DateTime.Now
            };
            packageBillRepository.Add(packageBill);

            return true;
        }
        /// <summary>
        /// 会员选课
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="listCourseScheduleId"></param>
        /// <returns></returns>
        public bool SelectCourses(int memberId, List<int> listCourseScheduleId)
        {
            var member = repository.GetById(memberId);
            //清除会员已选课程
            memberCourseScheduleRepository.CleanByMemberId(memberId);

            //新增会员选课
            foreach (var courseScheduleId in listCourseScheduleId)
            {
                var courseSchedule = courseScheduleRepository.GetById(courseScheduleId);
               
                var memberCourseSchedule = new MemberCourseSchedule
                {
                    MemberId = member.Id,
                    MemberName = member.Name,
                    CourseScheduleId = courseSchedule.Id,
                    ClassroomId = courseSchedule.ClassroomId,
                    ClassroomName = courseSchedule.ClassroomName,
                    CourseId = courseSchedule.CourseId,
                    CourseName = courseSchedule.CourseName,
                    TeacherId = courseSchedule.TeacherId,
                    TeacherName = courseSchedule.TeacherName,
                    StartTime = courseSchedule.StartTime,
                    EndTime = courseSchedule.EndTime,
                    DayOfWeek = courseSchedule.DayOfWeek
                };
                memberCourseScheduleRepository.Add(memberCourseSchedule);
            }
            return true;
        }
        /// <summary>
        /// 补卡
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public bool ReissueMembershipCard(int memberId, string cardId)
        {
            var member = repository.GetById(memberId);
            member.CardId = cardId;
            repository.Update(member);
            return true;
        }
        /// <summary>
        /// 获取门店会员数据
        /// </summary>
        /// <param name="studioId"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public List<Member> GetBranchStudioMembers(int studioId, string memberName)
        {
            return repository.GetBranchStudioMembers(studioId, memberName);
        }

        /// <summary>
        /// 递归扣除课时
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="hour"></param>
        private void DeductCourseHourRecursively(int memberId, int hour)
        {
            var member = repository.GetById(memberId);
            var memberPackage = memberPackageRepository.GetById(member.CurrentPackageid);
            //若剩余课时不小于课程课时，则扣除课时
            if (memberPackage.RemainingHour >= hour)
            {
                memberPackage.RemainingHour -= hour;
                memberPackageRepository.Update(memberPackage);
            }
            else
            {
                //否则，先扣除当前套餐剩余课时，然后更换套餐，再扣除剩余课程课时
                var extrahour = hour - memberPackage.RemainingHour;
                memberPackage.RemainingHour = 0;
                memberPackageRepository.Update(memberPackage);
                //更换套餐
                if (AutoChangeCurrentPackage(memberId))
                {
                    //继续扣课
                    DeductCourseHourRecursively(memberId, extrahour);
                }
                else
                {
                    //课时不足
                }
            }
        }
        /// <summary>
        /// 课时不足时，自动更换套餐
        /// </summary>
        /// <param name="memberId"></param>
        private bool AutoChangeCurrentPackage(int memberId)
        {
            var memberPackageList = memberPackageRepository.GetAllDeductableMemberPackages(memberId);
            if (memberPackageList.Count == 0)
            {
                return false;
            }
            //取第一个套餐（最快到期的套餐）
            var currentPackage = memberPackageList[0];
            var member = repository.GetById(memberId);
            member.CurrentPackageid = currentPackage.Id;
            member.CurrentPackagename = currentPackage.PackageName;
            repository.Update(member);
            return true;
        }
    }
}
