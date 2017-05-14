using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndiDance.Data;
using AndiDance.Persistence.RepositoryService;

namespace AndiDance.DomainModel
{
    public class ActivityDomainModel
    {
        private ActivityRepositoryService repositoryService = new ActivityRepositoryService();

        /// <summary>
        /// 获取所有活动列表
        /// </summary>
        /// <param name="activityName"></param>
        /// <returns></returns>
        public List<Activity> GetAllActivities(string activityName)
        {
            return repositoryService.GetAllActivities(activityName);
        }
        /// <summary>
        /// 添加活动
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        public bool AddActivity(Activity activity)
        {
            return repositoryService.AddActivity(activity);
        }
        /// <summary>
        /// 获取活动详情
        /// </summary>
        /// <param name="activityId"></param>
        /// <returns></returns>
        public Activity GetActivityDetail(int activityId)
        {
            return repositoryService.GetActivityDetail(activityId);
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
            return repositoryService.AddPackageToActivity(packageId, activityId, activityPrice, activityHour, activityDuration);
        }
    }
}
