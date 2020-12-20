using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinyuLi.TaskManagerSystem.Core.Models.Request;
using XinyuLi.TaskManagerSystem.Core.Models.Response;
using XinyuLi.TaskManagerSystem.Core.RepositoryInterfaces;
using XinyuLi.TaskManagerSystem.Core.ServiceInterfaces;

namespace XinyuLi.TaskManagerSystem.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository repository)
        {
            _taskRepository = repository;
        }

        public async Task<TaskResponseModel> CreateTask(TaskRequestModel requestModel)
        {
            var t = new Core.Entities.Task
            {
                UserId = requestModel.UserId,
                Title = requestModel.Title,
                Description = requestModel.Description,
                DueDate = requestModel.DueDate,
                Priority = requestModel.Priority,
                Remarks = requestModel.Remarks
            };
            var createdTask = await _taskRepository.AddAsync(t);
            var response = new TaskResponseModel
            {
                Id = createdTask.Id,
                UserId = createdTask.UserId,
                Title = createdTask.Title,
                Description = createdTask.Description,
                DueDate = createdTask.DueDate,
                Priority = createdTask.Priority,
                Remarks = createdTask.Remarks
            };
            return response;
        }

        public async Task UpdateTask(int id, TaskRequestModel requestModel)
        {
            var newTask = await _taskRepository.GetByIdAsync(id);
            if (newTask == null) 
            {
                throw new Exception("This task does not exist.");
            }
            newTask.UserId = requestModel.UserId;
            newTask.Title = requestModel.Title;
            newTask.Description = requestModel.Description;
            newTask.DueDate = requestModel.DueDate;
            newTask.Priority = requestModel.Priority;
            newTask.Remarks = requestModel.Remarks;

            await _taskRepository.UpdateAsync(newTask);
        }

        public async System.Threading.Tasks.Task DeleteTask(int id)
        {
            var h = await _taskRepository.ListAsync(t => t.Id == id);
            await _taskRepository.DeleteAsync(h.First());
        }

        public async Task<IEnumerable<TaskResponseModel>> GetTasksByUserId(int userId)
        {
            var tasks = await _taskRepository.GetTasksByUserId(userId);
            if (!tasks.Any())
            {
                throw new Exception("No Tasks Found");
            }
            var response = new List<TaskResponseModel>();
            foreach (var task in tasks)
            {
                response.Add(new TaskResponseModel
                {
                    Id = task.Id,
                    UserId = task.UserId,
                    Title = task.Title,
                    DueDate = task.DueDate,
                    Priority = task.Priority,
                    Remarks = task.Remarks
                });
            }
            return response;
        }
    }
}
