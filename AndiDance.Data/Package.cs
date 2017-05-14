using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Data
{
    /// <summary>
    /// 套餐
    /// </summary>
    public class Package : Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 所属门店id
        /// </summary>
        public int StudioId { get; set; }
        /// <summary>
        /// 所属门店名
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
        /// 消费模式
        /// </summary>
        public string ConsumptionMode { get; set; }
        /// <summary>
        /// 最低消费周期单位
        /// </summary>
        public string MinConsumptionUnit { get; set; }
        /// <summary>
        /// 最低消费课时
        /// </summary>
        public int MinConsumptionHour { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 当前活动id
        /// </summary>
        public int ActivityId { get; set; }
        /// <summary>
        /// 当前活动名称
        /// </summary>
        public string ActivityName { get; set; }
        /// <summary>
        /// 活动套餐价格
        /// </summary>
        public double ActivityPrice { get; set; }
        /// <summary>
        /// 活动套餐课时
        /// </summary>
        public int ActivityHour { get; set; }
        /// <summary>
        /// 活动套餐时限
        /// </summary>
        public int ActivityDuration { get; set; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}
