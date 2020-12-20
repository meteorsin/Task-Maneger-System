using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XinyuLi.TaskManagerSystem.Core.Entities;

namespace XinyuLi.TaskManagerSystem.Core.RepositoryInterfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserByEmail(string email);
    }
}
