using AndiDance.Data;
using AndiDance.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Persistence.RepositoryService
{
    public class ChargeBillRepositoryService : BaseRepositoryService
    {
        private ChargeBillRepository repository = new ChargeBillRepository();

        /// <summary>
        /// 获取所有充值账单列表
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="memberName"></param>
        /// <returns></returns>
        public List<ChargeBill> GetAllChargeBills(string startTime, string endTime, string memberName)
        {
            return repository.Search(startTime, endTime, memberName);
        }
        /// <summary>
        /// 获取充值账单详情
        /// </summary>
        /// <param name="chargeBillId"></param>
        /// <returns></returns>
        public ChargeBill GetChargeBillDetail(int chargeBillId)
        {
            return repository.GetById(chargeBillId);
        }
    }
}
