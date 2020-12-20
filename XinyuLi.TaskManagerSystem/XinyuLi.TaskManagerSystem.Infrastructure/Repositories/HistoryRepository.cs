using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XinyuLi.TaskManagerSystem.Core.Entities;
using XinyuLi.TaskManagerSystem.Core.RepositoryInterfaces;
using XinyuLi.TaskManagerSystem.Infrastructure.Data;

namespace XinyuLi.TaskManagerSystem.Infrastructure.Repositories
{
    public class HistoryRepository : EfRepository<Core.Entities.TaskHistory>, IHistoryRepository
    {
        public HistoryRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {

        }
        public Task<IEnumerable<TaskHistory>> GetCompletedTasks(DateTime Completed)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskHistory>> GetUncompletedTasks(DateTime Completed)
        {
            throw new NotImplementedException();
        }
    }
}
