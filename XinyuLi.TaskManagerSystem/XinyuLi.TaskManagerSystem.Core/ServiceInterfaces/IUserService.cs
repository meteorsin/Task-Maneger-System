using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XinyuLi.TaskManagerSystem.Core.Models.Request;
using XinyuLi.TaskManagerSystem.Core.Models.Response;

namespace XinyuLi.TaskManagerSystem.Core.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> CreateUser(UserRegisterRequestModel requestModel);
        Task<UserLoginResponseModel> ValidateUser(string email, string password);
        Task UpdateUser(int id, UserRegisterRequestModel u);
        Task DeleteUser(int id);
    }
}
