using AndiDance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;
using System.Data;

namespace AndiDance.Persistence.Repository
{
    public class StudioRepository : BaseRepository<Studio>
    {
        public StudioRepository()
        {
            _dbTableName = "studio";
            _fieldMap.Add("name", "Name");
            _fieldMap.Add("address", "Address");
            _fieldMap.Add("city", "City");
            _fieldMap.Add("district", "District");
            _fieldMap.Add("managerid", "ManagerId");
            _fieldMap.Add("managername", "ManagerName");
        }
    }
}
