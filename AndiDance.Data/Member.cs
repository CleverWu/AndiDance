using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Data
{
    /// <summary>
    /// 会员
    /// </summary>
    public class Member : Entity
    {
        /// <summary>
        /// 会员卡号
        /// </summary>
        public string CardId { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// 会员类型
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        public string QQ { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 年龄
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegDate { get; set; }
        /// <summary>
        /// 门店id
        /// </summary>
        public int StudioId { get; set; }
        /// <summary>
        /// 门店名
        /// </summary>
        public string StudioName { get; set; }
        /// <summary>
        /// 办理人id
        /// </summary>
        public int TransactorId { get; set; }
        /// <summary>
        /// 办理人姓名
        /// </summary>
        public string TransactorName { get; set; }
        /// <summary>
        /// 课程顾问id
        /// </summary>
        public int CourseCounselorId { get; set; }
        /// <summary>
        /// 课程顾问姓名
        /// </summary>
        public string CourseCounselorName { get; set; }
        /// <summary>
        /// 余额
        /// </summary>
        public double Balance { get; set; }
        /// <summary>
        /// 当前套餐id
        /// </summary>
        public int CurrentPackageid { get; set; }
        /// <summary>
        /// 当前套餐名称
        /// </summary>
        public string CurrentPackagename { get; set; }
        /// <summary>
        /// 上一次上课id
        /// </summary>
        public int LastCourseScheduleId { get; set; }
        /// <summary>
        /// 上一次课程名称
        /// </summary>
        public string LastCourseName { get; set; }
        /// <summary>
        /// 上一次课程开始时间
        /// </summary>
        public DateTime LastCourseStartTime { get; set; }
        /// <summary>
        /// 上一次课程结束时间
        /// </summary>
        public DateTime LastCourseEndTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks { get; set; }
        /// <summary>
        /// 是否已删除
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 正在上课中
        /// </summary>
        public bool IsInClass { get; set; }
    }
}
