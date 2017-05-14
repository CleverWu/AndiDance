using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Data
{
    /// <summary>
    /// 充值账单
    /// </summary>
    public class ChargeBill : Entity
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
        /// 收款人
        /// </summary>
        public int PayeeId { get; set; }
        /// <summary>
        /// 收款人姓名
        /// </summary>
        public string PayeeName { get; set; }
        /// <summary>
        /// 支付方式
        /// </summary>
        public string PaymentMethod { get; set; }
        /// <summary>
        /// 金额
        /// </summary>
        public double Amount { get; set; }
        /// <summary>
        /// 收款单据号
        /// </summary>
        public string ReceiptNumber { get; set; }
        /// <summary>
        /// 账单时间
        /// </summary>
        public DateTime Time { get; set; }
    }
}
