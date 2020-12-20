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
    public class TaskHistoriesController : ControllerBase
    {
        private readonly IHistoryService _taskHistoryService;
        private readonly IHistoryRepository _taskHistoryRepository;
        public TaskHistoriesController(IHistoryService taskHistoryService, IHistoryRepository taskHistoryRepository)
        {
            _taskHistoryService = taskHistoryService;
            _taskHistoryRepository = taskHistoryRepository;
        }

        [HttpPost("create")]
        public async Task<ActionResult> RegisterUserAsync([FromBody] HistoryRequestModel t)
        {
            var createdTask = await _taskHistoryService.CreateHistory(t);
            return CreatedAtRoute("GetUser", new { id = createdTask.TaskId }, createdTask);
        }

        [HttpPut("update/{id:int}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] HistoryRequestModel t)
        {
            await _taskHistoryService.UpdateHistory(id, t);
            return Ok();
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _taskHistoryService.DeleteHistory(id);
            return NoContent();
        }
        [HttpGet("")]
        public async Task<IActionResult> GetTasks()
        {
            var task = await _taskHistoryRepository.ListAllAsync();
            return Ok(task);
        }
    }
}
