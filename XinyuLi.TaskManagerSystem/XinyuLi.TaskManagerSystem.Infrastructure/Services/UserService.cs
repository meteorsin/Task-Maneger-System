using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinyuLi.TaskManagerSystem.Core.Entities;
using XinyuLi.TaskManagerSystem.Core.Models.Request;
using XinyuLi.TaskManagerSystem.Core.Models.Response;
using XinyuLi.TaskManagerSystem.Core.RepositoryInterfaces;
using XinyuLi.TaskManagerSystem.Core.ServiceInterfaces;

namespace XinyuLi.TaskManagerSystem.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository repository)
        {
            _userRepository = repository;            
        }
        public async Task<UserRegisterResponseModel> CreateUser(UserRegisterRequestModel requestModel)
        {
            var dbUser = await _userRepository.GetUserByEmail(requestModel.Email);
            // Make sure email does not exists in the database
            if (dbUser != null && string.Equals(dbUser.Email, requestModel.Email, StringComparison.CurrentCultureIgnoreCase))
                throw new Exception("Email Already Exits");
            var user = new User
            {
                Email = requestModel.Email,
                Password = requestModel.Password,
                Fullname = requestModel.Fullname,
                Mobileno = requestModel.Mobileno
            };
            var createdUser = await _userRepository.AddAsync(user);
            var response = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                Fullname = requestModel.Fullname,
                Mobileno = requestModel.Mobileno
            };
            return response;
        }

        public async Task<UserLoginResponseModel> ValidateUser(string email, string password)
        {
            // we are gonna check if the email exists in the database
            var user = await _userRepository.GetUserByEmail(email);

            var isSuccess = user.Password == password;
            var response = new UserLoginResponseModel
            {
                Email = user.Email,
                Fullname = user.Fullname,
                Mobileno = user.Mobileno
            };

            if (isSuccess)
                return response;
            else
                return null;
        }

        public async Task<UserRegisterResponseModel> GetUserDetails(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
                throw new Exception("No User Found");

            //var response = _mapper.Map<UserRegisterResponseModel>(user);
            var response = new UserRegisterResponseModel
            {
                Email = user.Email,
                Fullname = user.Fullname,
                Mobileno = user.Mobileno
            };
            return response;
        }
        //public async Task<User> GetUserById(int id)
        //{
        //    return await _userRepository.GetUserById(id);
        //}

        public async Task<User> GetUserByEmail(string e)
        {
            return await _userRepository.GetUserByEmail(e);
        }

        public async System.Threading.Tasks.Task UpdateUser(int id, UserRegisterRequestModel u)
        {
            var newUser = await _userRepository.GetByIdAsync(id);
            if (newUser == null)
            {
                throw new Exception("This task does not exist.");
            }

            newUser.Email = u.Email;
            newUser.Password = u.Password;
            newUser.Fullname = u.Fullname;
            newUser.Mobileno = u.Mobileno;

            await _userRepository.UpdateAsync(newUser);
        }

        public async System.Threading.Tasks.Task DeleteUser(int id)
        {
            var user = await _userRepository.ListAsync(u => u.Id == id);
            await _userRepository.DeleteAsync(user.First());
        }
    }
}
