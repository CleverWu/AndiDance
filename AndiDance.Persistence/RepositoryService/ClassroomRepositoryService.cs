using AndiDance.Data;
using AndiDance.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndiDance.Persistence.RepositoryService
{
    public class ClassroomRepositoryService : BaseRepositoryService
    {
        private ClassroomRepository repository = new ClassroomRepository();

        /// <summary>
        /// 获取所有教室列表
        /// </summary>
        /// <returns></returns>
        public List<Classroom> GetAllClassrooms()
        {
            return repository.GetAll();
        }
        /// <summary>
        /// 添加教室
        /// </summary>
        /// <param name="classroom"></param>
        /// <returns></returns>
        public bool AddClassroom(Classroom classroom)
        {
            repository.Add(classroom);
            return true;
        }
        /// <summary>
        /// 获取教室信息
        /// </summary>
        /// <param name="classroomId"></param>
        /// <returns></returns>
        public Classroom GetClassroomDetail(int classroomId)
        {
            return repository.GetById(classroomId);
        }
    }
}
