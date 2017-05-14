using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Data
{
    /// <summary>
    /// 员工
    /// </summary>
    public class Employee : Entity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 所属门店id
        /// </summary>
        public int StudioId { get; set; }
        /// <summary>
        /// 所属门店名
        /// </summary>
        public string StudioName { get; set; }
        /// <summary>
        /// 住址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 账号
        /// </summary>
        public string Account { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 是否为老师
        /// </summary>
        public bool IsTeacher { get; set; }
        /// <summary>
        /// 任职情况（兼职、全职）
        /// </summary>
        public string JobStatus { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 是否已离职
        /// </summary>
        public bool IsDismissed { get; set; }
        /// <summary>
        /// 离职原因
        /// </summary>
        public string DismissionReason { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
