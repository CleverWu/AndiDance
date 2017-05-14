using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndiDance.Data;
using AndiDance.Persistence.RepositoryService;

namespace AndiDance.DomainModel
{
    public class FinanceDomainModel
    {
        private ChargeBillRepositoryService chargeBillRepositoryService = new ChargeBillRepositoryService();
        private PackageBillRepositoryService packageBillRepositoryService = new PackageBillRepositoryService();

        /// <summary>
        /// 获取所有充值账单列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public List<ChargeBill> GetAllChargeBills(string startTime, string endTime, string memberName)
        {
            return chargeBillRepositoryService.GetAllChargeBills(startTime, endTime, memberName);
        }
        /// <summary>
        /// 获取充值账单详情
        /// </summary>
        /// <param name="chargeBillId"></param>
        /// <returns></returns>
        public ChargeBill GetChargeBillDetail(int chargeBillId)
        {
            return chargeBillRepositoryService.GetChargeBillDetail(chargeBillId);
        }
        /// <summary>
        /// 获取所有套餐账单列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public List<PackageBill> GetAllPackageBills(string startTime, string endTime, string memberName)
        {
            return packageBillRepositoryService.GetAllPackageBills(startTime, endTime, memberName);
        }
        /// <summary>
        /// 获取套餐账单详情
        /// </summary>
        /// <param name="packageBillId"></param>
        /// <returns></returns>
        public PackageBill GetPackageBillDetail(int packageBillId)
        {
            return packageBillRepositoryService.GetPackageBillDetail(packageBillId);
        }
    }
}
