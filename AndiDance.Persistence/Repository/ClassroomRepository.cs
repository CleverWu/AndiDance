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
    public class ClassroomRepository : BaseRepository<Classroom>
    {
        public ClassroomRepository()
        {
            _dbTableName = "classroom";
            _fieldMap.Add("name", "Name");
            _fieldMap.Add("studioid", "StudioId");
            _fieldMap.Add("studioname", "StudioName");
        }
    }
}
