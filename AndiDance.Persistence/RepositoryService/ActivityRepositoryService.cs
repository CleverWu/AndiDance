using AndiDance.Data;
using AndiDance.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Persistence.RepositoryService
{
    public class ActivityRepositoryService : BaseRepositoryService
    {
        private ActivityRepository repository = new ActivityRepository();
        private PackageRepository packageRepository = new PackageRepository();

        /// <summary>
        /// 获取所有活动列表
        /// </summary>
        /// <param name="activityName"></param>
        /// <returns></returns>
        public List<Activity> GetAllActivities(string activityName)
        {
            return repository.Search(activityName);
        }
        /// <summary>
        /// 添加活动
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public bool AddActivity(Activity activity)
        {
            repository.Add(activity);
            return true;
        }
        /// <summary>
        /// 获取活动详情
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public Activity GetActivityDetail(int activityId)
        {
            return repository.GetById(activityId);
        }
        /// <summary>
        /// 为活动添加套餐应用
        /// </summary>
        /// <param name="packageId"></param>
        /// <param name="activityId"></param>
        /// <param name="activityPrice"></param>
        /// <param name="activityHour"></param>
        /// <param name="activityDuration"></param>
        /// <returns></returns>
        public bool AddPackageToActivity(int packageId, int activityId, double activityPrice, int activityHour, int activityDuration)
        {
            var package = packageRepository.GetById(packageId);
            var activity = repository.GetById(activityId);
            package.ActivityId = activityId;
            package.ActivityName = activity.Name;
            package.ActivityPrice = activityPrice;
            package.ActivityHour = activityHour;
            package.ActivityDuration = activityDuration;
            packageRepository.Update(package);
            return true;
        }
    }
}
