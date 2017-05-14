using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Data
{
    public class ActionRecord : Entity
    {
        /// <summary>
        /// 操作人id
        /// </summary>
        public int ActorId { get; set; }
        /// <summary>
        /// 操作人姓名
        /// </summary>
        public string ActorName { get; set; }
        /// <summary>
        /// 操作对象类型
        /// </summary>
        public string ObjectType { get; set; }
        /// <summary>
        /// 操作对象id
        /// </summary>
        public int ObjectId { get; set; }
        /// <summary>
        /// 操作对象名称
        /// </summary>
        public string ObjectName { get; set; }
        /// <summary>
        /// 操作
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime Time { get; set; }
    }
}
