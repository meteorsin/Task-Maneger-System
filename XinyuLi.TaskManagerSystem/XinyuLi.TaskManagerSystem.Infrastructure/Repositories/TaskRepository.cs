using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinyuLi.TaskManagerSystem.Core.RepositoryInterfaces;
using XinyuLi.TaskManagerSystem.Infrastructure.Data;

namespace XinyuLi.TaskManagerSystem.Infrastructure.Repositories
{
    public class TaskRepository : EfRepository<Core.Entities.Task>, ITaskRepository
    {
        public TaskRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Core.Entities.Task>> GetTasksByUserId(int UserId)
        {
            var t =  _dbContext.Tasks.Where(g => g.UserId == UserId);
            var tasks = await t.ToListAsync();
            return tasks;
        }
    }

}
