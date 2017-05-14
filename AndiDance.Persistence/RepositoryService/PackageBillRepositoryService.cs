using AndiDance.Data;
using AndiDance.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Persistence.RepositoryService
{
    public class PackageBillRepositoryService : BaseRepositoryService
    {
        private PackageBillRepository repository = new PackageBillRepository();

        /// <summary>
        /// 获取所有套餐账单列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public List<PackageBill> GetAllPackageBills(string startTime, string endTime, string memberName)
        {
            return repository.GetAllPackageBills(startTime, endTime, memberName);
        }
        /// <summary>
        /// 获取套餐账单详情
        /// </summary>
        /// <param name="packageBillId"></param>
        /// <returns></returns>
        public PackageBill GetPackageBillDetail(int packageBillId)
        {
            return repository.GetById(packageBillId);
        }
    }
}
