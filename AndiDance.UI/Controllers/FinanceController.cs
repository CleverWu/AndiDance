using AndiDance.Data;
using AndiDance.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndiDance.UI.Controllers
{
    public class FinanceController : Controller
    {
        private FinanceDomainModel domainModel = new FinanceDomainModel();

        /// <summary>
        /// 今日新增储值相关数据
        /// </summary>
        /// <param name="payee">收款人</param>
        /// <param name="memberName">会员名</param>
        /// <returns></returns>
        public JsonResult GetNewChargeBillsTodayData(string payee, string memberName)
        {
            return null;
        }
        /// <summary>
        /// 今日新增开单相关数据
        /// </summary>
        /// <param name="memberName">会员名</param>
        /// <returns></returns>
        public JsonResult GetNewPackageBillsTodayData(string memberName)
        {
            return null;
        }

        #region 充值账单
        /// <summary>
        /// 会员财务页面
        /// </summary>
        /// <returns></returns>
        public ActionResult MemberFinanceView()
        {
            return View();
        }
        /// <summary>
        /// 获取所有充值账单列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public JsonResult GetAllChargeBills(string startTime, string endTime, string memberName)
        {
            List<ChargeBill> chargeBillList = domainModel.GetAllChargeBills(startTime, endTime, memberName);
            return Json(chargeBillList);
        }
        /// <summary>
        /// 获取充值账单详情
        /// </summary>
        /// <param name="chargeBillId"></param>
        /// <returns></returns>
        public JsonResult GetChargeBillDetail(int chargeBillId)
        {
            ChargeBill chargeBill = domainModel.GetChargeBillDetail(chargeBillId);
            return Json(chargeBill);
        }
        #endregion

        #region 套餐账单
        /// <summary>
        /// 套餐账单页面
        /// </summary>
        /// <returns></returns>
        public ActionResult PackageBillRecordView()
        {
            return View();
        }
        /// <summary>
        /// 获取所有套餐账单列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public JsonResult GetAllPackageBills(string startTime, string endTime, string memberName)
        {
            List<PackageBill> packageBillList = domainModel.GetAllPackageBills(startTime, endTime, memberName);
            return Json(packageBillList);
        }
        /// <summary>
        /// 获取套餐账单详情
        /// </summary>
        /// <param name="packageBillId"></param>
        /// <returns></returns>
        public JsonResult GetPackageBillDetail(int packageBillId)
        {
            PackageBill packageBill = domainModel.GetPackageBillDetail(packageBillId);
            return Json(packageBill);
        }
        #endregion
    }
}