using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XinyuLi.TaskManagerSystem.Core.Models.Request;
using XinyuLi.TaskManagerSystem.Core.Models.Response;

namespace XinyuLi.TaskManagerSystem.Core.ServiceInterfaces
{
    public interface ITaskService
    {
        Task<TaskResponseModel> CreateTask(TaskRequestModel requestModel);
        System.Threading.Tasks.Task UpdateTask(int id, TaskRequestModel requestModel);
        Task DeleteTask(int id);
        Task<IEnumerable<TaskResponseModel>> GetTasksByUserId(int userId);
    }
}
