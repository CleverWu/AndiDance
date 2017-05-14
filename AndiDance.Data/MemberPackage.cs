using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Data
{
    /// <summary>
    /// 会员已选的套餐
    /// </summary>
    public class MemberPackage : Entity
    {
        /// <summary>
        /// 所属套餐id
        /// </summary>
        public int PackageId { get; set; }
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
        /// 所属会员id
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 会员姓名
        /// </summary>
        public string MemberName { get; set; }
        /// <summary>
        /// 所属门店
        /// </summary>
        public int StudioId { get; set; }
        /// <summary>
        /// 门店名
        /// </summary>
        public string StudioName { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// 课时
        /// </summary>
        public int Hour { get; set; }
        /// <summary>
        /// 持续时限
        /// </summary>
        public int Duration { get; set; }
        /// <summary>
        /// 剩余课时
        /// </summary>
        public int RemainingHour { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public DateTime StartTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// 是否正在使用中
        /// </summary>
        public bool IsInUse { get; set; }
        /// <summary>
        /// 是否冻结中
        /// </summary>
        public bool IsFrozen { get; set; }
        /// <summary>
        /// 冻结起始时间
        /// </summary>
        public DateTime FreezeStartTime { get; set; }
        /// <summary>
        /// 冻结结束时间
        /// </summary>
        public DateTime FreezeEndTime { get; set; }
    }
}
