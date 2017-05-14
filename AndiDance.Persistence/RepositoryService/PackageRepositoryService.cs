using AndiDance.Data;
using AndiDance.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Persistence.RepositoryService
{
    public class PackageRepositoryService : BaseRepositoryService
    {
        private PackageRepository repository = new PackageRepository();
        private ActivityRepository activityRepository = new ActivityRepository();

        /// <summary>
        /// 获取所有套餐列表
        /// </summary>
        /// <param name="packageName"></param>
        /// <returns></returns>
        public List<Package> GetAllPackages(string packageName)
        {
            return repository.Search(packageName);
        }
        /// <summary>
        /// 添加套餐
        /// </summary>
        /// <param name="package"></param>
        /// <returns></returns>
        public bool AddPackage(Package package)
        {
            repository.Add(package);
            return true;
        }
        /// <summary>
        /// 获取套餐详情
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public Package GetPackageDetail(int packageId)
        {
            return repository.GetById(packageId);
        }
        /// <summary>
        /// 启用套餐
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public bool EnablePackage(int packageId)
        {
            var package = repository.GetById(packageId);
            package.IsAvailable = true;
            repository.Update(package);
            return true;
        }
        /// <summary>
        /// 停用套餐
        /// </summary>
        /// <param name="packageId"></param>
        /// <returns></returns>
        public bool DisablePackage(int packageId)
        {
            var package = repository.GetById(packageId);
            package.IsAvailable = false;
            repository.Update(package);
            return true;
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
            var package = repository.GetById(packageId);
            var activity = activityRepository.GetById(activityId);
            package.ActivityId = activityId;
            package.ActivityName = activity.Name;
            package.ActivityPrice = activityPrice;
            package.ActivityHour = activityHour;
            package.ActivityDuration = activityDuration;
            repository.Update(package);
            return true;
        }
    }
}
