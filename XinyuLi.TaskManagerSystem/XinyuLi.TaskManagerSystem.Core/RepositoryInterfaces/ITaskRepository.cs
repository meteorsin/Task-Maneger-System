using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace XinyuLi.TaskManagerSystem.Core.RepositoryInterfaces
{
    public interface ITaskRepository : IAsyncRepository<Entities.Task>
    {
        Task<IEnumerable<Entities.Task>> GetTasksByUserId(int UserId);
    }
}
