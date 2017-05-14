using AndiDance.Data;
using AndiDance.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AndiDance.UI.Controllers
{
    public class PackageController : Controller
    {
        private PackageDomainModel domainModel = new PackageDomainModel();

        /// <summary>
        /// 套餐设置页面
        /// </summary>
        /// <returns></returns>
        public ActionResult PackageSettingView()
        {
            return View();
        }
        /// <summary>
        /// 获取所有套餐列表
        /// </summary>
        /// <param name="packageName"></param>
        /// <returns></returns>
        public JsonResult GetAllPackages(string packageName)
        {
            List<Package> packageList = domainModel.GetAllPackages(packageName);
            return Json(packageList);
        }
        /// <summary>
        /// 添加套餐页面
        /// </summary>
        /// <returns></returns>
        public ActionResult PackageAddingView()
        {
            return View();
        }
        /// <summary>
        /// 添加套餐
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        public bool AddPackage(Package package)
        {
            return domainModel.AddPackage(package);
        }
        /// <summary>
        /// 套餐详情页面
        /// </summary>
        /// <returns></returns>
        public ActionResult PackageDetailView()
        {
            return View();
        }
        /// <summary>
        /// 获取套餐详情
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public JsonResult GetPackageDetail(int packageId)
        {
            Package package = domainModel.GetPackageDetail(packageId);
            return Json(package);
        }
        /// <summary>
        /// 启用套餐
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public bool EnablePackage(int packageId)
        {
            return domainModel.EnablePackage(packageId);
        }
        /// <summary>
        /// 停用套餐
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public bool DisablePackage(int packageId)
        {
            return domainModel.DisablePackage(packageId);
        }
        /// <summary>
        /// 更换套餐活动
        /// </summary>
        /// <param name="packageId"></param>
        /// <param name="activityId"></param>
        /// <param name="activityPrice"></param>
        /// <param name="activityHour"></param>
        /// <param name="activityDuration"></param>
        /// <returns></returns>
        public bool ChangeActivity(int packageId, int activityId, double activityPrice, int activityHour, int activityDuration)
        {
            return domainModel.ChangeActivity(packageId, activityId, activityPrice, activityHour, activityDuration);
        }
    }
}