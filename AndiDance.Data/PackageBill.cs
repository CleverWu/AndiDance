using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Data
{
    /// <summary>
    /// 套餐账单
    /// </summary>
    public class PackageBill : Entity
    {
        /// <summary>
        /// 所属门店
        /// </summary>
        public int StudioId { get; set; }
        /// <summary>
        /// 门店名
        /// </summary>
        public string StudioName { get; set; }
        /// <summary>
        /// 所属会员id
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 办理人id
        /// </summary>
        public int TransactorId { get; set; }
        /// <summary>
        /// 办理人姓名
        /// </summary>
        public string TransactorName { get; set; }
        /// <summary>
        /// 会员已选的套餐id
        /// </summary>
        public int MemberPackageId { get; set; }
        /// <summary>
        /// 套餐名称
        /// </summary>
        public string PackageName { get; set; }
        /// <summary>
        /// 活动id
        /// </summary>
        public int ActivityId { get; set; }
        /// <summary>
        /// 活动名称
        /// </summary>
        public string ActivityName { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 课时
        /// </summary>
        public int Hour { get; set; }
        /// <summary>
        /// 账单时间
        /// </summary>
        public DateTime Time { get; set; }
    }
}
