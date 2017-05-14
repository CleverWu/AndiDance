using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndiDance.Data;
using AndiDance.Persistence.RepositoryService;

namespace AndiDance.DomainModel
{
    public class ClassroomDomainModel
    {
        private ClassroomRepositoryService repositoryService = new ClassroomRepositoryService();

        /// <summary>
        /// 获取所有教室列表
        /// </summary>
        /// <returns></returns>
        public List<Classroom> GetAllClassrooms()
        {
            return repositoryService.GetAllClassrooms();
        }
        /// <summary>
        /// 添加教室
        /// </summary>
        /// <param name="classroom"></param>
        /// <returns></returns>
        public bool AddClassroom(Classroom classroom)
        {
            return repositoryService.AddClassroom(classroom);
        }
        /// <summary>
        /// 获取教室信息
        /// </summary>
        /// <param name="classroomId"></param>
        /// <returns></returns>
        public Classroom GetClassroomDetail(int classroomId)
        {
            return repositoryService.GetClassroomDetail(classroomId);
        }
    }
}
