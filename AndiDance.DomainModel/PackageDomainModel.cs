using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndiDance.Data;
using AndiDance.Persistence.RepositoryService;

namespace AndiDance.DomainModel
{
    public class PackageDomainModel
    {
        private PackageRepositoryService repositoryService = new PackageRepositoryService();

        /// <summary>
        /// 获取所有套餐列表
        /// </summary>
        /// <param name="packageName"></param>
        /// <returns></returns>
        public List<Package> GetAllPackages(string packageName)
        {
            return repositoryService.GetAllPackages(packageName);
        }
        /// <summary>
        /// 添加套餐
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        public bool AddPackage(Package package)
        {
            return repositoryService.AddPackage(package);
        }
        /// <summary>
        /// 获取套餐详情
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public Package GetPackageDetail(int packageId)
        {
            return repositoryService.GetPackageDetail(packageId);
        }
        /// <summary>
        /// 启用套餐
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public bool EnablePackage(int packageId)
        {
            return repositoryService.EnablePackage(packageId);
        }
        /// <summary>
        /// 停用套餐
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public bool DisablePackage(int packageId)
        {
            return repositoryService.DisablePackage(packageId);
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
            return repositoryService.ChangeActivity(packageId, activityId, activityPrice, activityHour, activityDuration);
        }
    }
}
