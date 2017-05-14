using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Data
{
    /// <summary>
    /// 课程
    /// </summary>
    public class Course : Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 支付课时
        /// </summary>
        public int CostHour { get; set; }
        /// <summary>
        /// 舞种
        /// </summary>
        public string DanceType { get; set; }
        /// <summary>
        /// 班级类型
        /// </summary>
        public string ClassType { get; set; }
        /// <summary>
        /// 课程类型
        /// </summary>
        public string CourseType { get; set; }
        /// <summary>
        /// 所属门店
        /// </summary>
        public int StudioId { get; set; }
        /// <summary>
        /// 门店名
        /// </summary>
        public string StudioName { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}
