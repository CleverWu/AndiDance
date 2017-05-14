using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Data
{
    /// <summary>
    /// 门店
    /// </summary>
    public class Studio : Entity
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 区
        /// </summary>
        public string District { get; set; }
        /// <summary>
        /// 店长id
        /// </summary>
        public int ManagerId { get; set; }
        /// <summary>
        /// 店长姓名
        /// </summary>
        public string ManagerName { get; set; }
    }
}
