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
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly ITaskRepository _taskRepository;
        public TasksController(ITaskService taskService, ITaskRepository taskRepository)
        {
            _taskService = taskService;
            _taskRepository = taskRepository;
        }

        [HttpPost("create")]
        public async Task<ActionResult> RegisterUserAsync([FromBody] TaskRequestModel t)
        {
            var createdTask = await _taskService.CreateTask(t);
            return CreatedAtRoute("GetUser", new { id = createdTask.Id }, createdTask);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] TaskRequestModel t)
        {
            await _taskService.UpdateTask(id,t);
            return Ok();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _taskService.DeleteTask(id);
            return NoContent();
        }
        [HttpGet("")]
        public async Task<IActionResult> GetTasks()
        {
            var task = await _taskRepository.ListAllAsync();
            return Ok(task);
        }

        [HttpGet]
        [Route("user/{userId:int}")]
        public async Task<IActionResult> GetTasksByUserId(int userId)
        {
            var tasks = await _taskService.GetTasksByUserId(userId);
            return Ok(tasks);
        }

    }
}
