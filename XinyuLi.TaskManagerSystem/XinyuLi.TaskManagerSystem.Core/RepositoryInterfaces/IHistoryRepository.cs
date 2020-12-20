using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XinyuLi.TaskManagerSystem.Core.Entities;

namespace XinyuLi.TaskManagerSystem.Core.RepositoryInterfaces
{
    public interface IHistoryRepository : IAsyncRepository<TaskHistory>
    {
        Task<IEnumerable<TaskHistory>> GetCompletedTasks(DateTime Completed);
        Task<IEnumerable<TaskHistory>> GetUncompletedTasks(DateTime Completed);
    }
} 
           