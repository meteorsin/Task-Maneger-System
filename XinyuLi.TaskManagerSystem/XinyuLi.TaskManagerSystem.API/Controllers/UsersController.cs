using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XinyuLi.TaskManagerSystem.Core.Models.Request;
using XinyuLi.TaskManagerSystem.Core.RepositoryInterfaces;
using XinyuLi.TaskManagerSystem.Core.ServiceInterfaces;

namespace XinyuLi.TaskManagerSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {        
        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;
        public UsersController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> RegisterUserAsync([FromBody] UserRegisterRequestModel user)
        {
            var createdUser = await _userService.CreateUser(user);
            return CreatedAtRoute("GetUser", new { id = createdUser.Id }, createdUser);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginRequestModel loginRequestModel)
        {
            if (ModelState.IsValid)
            {
                var userLogin = await _userService.ValidateUser(loginRequestModel.Email, loginRequestModel.Password);
                if (userLogin != null)
                {
                    // success, here geenrate the JWT                    
                    return Ok();
                }                
            }
            return BadRequest(new { message = "Invalid email or password" });
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] UserRegisterRequestModel u)
        {
            await _userService.UpdateUser(id, u);
            return Ok();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
            return NoContent();
        }

        [HttpGet]        
        public async Task<IActionResult> GetUsers()
        {            
            var user = await _userRepository.ListAllAsync();
            return Ok(user);
        }

        // ================================

        [HttpGet]
        [Route("{id:int}", Name = "GetUser")]
        public async Task<IActionResult> GetUserById()
        {
            return Ok();
        }
    }
}
