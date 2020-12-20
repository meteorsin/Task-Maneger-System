using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XinyuLi.TaskManagerSystem.Core.Entities;
using XinyuLi.TaskManagerSystem.Core.RepositoryInterfaces;
using XinyuLi.TaskManagerSystem.Infrastructure.Data;

namespace XinyuLi.TaskManagerSystem.Infrastructure.Repositories
{
    public class UserRepository : EfRepository<User>, IUserRepository
    {
        public UserRepository(TaskManagerDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
