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
   public class HistoryService: IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;
        public HistoryService(IHistoryRepository repository)
        {
            _historyRepository = repository;
        }

        public async Task<HistoryResponseModel> CreateHistory(HistoryRequestModel requestModel)
        {
            var t = new TaskHistory
            {
                TaskId = requestModel.TaskId,
                UserId = requestModel.UserId,
                Title = requestModel.Title,
                Description = requestModel.Description,
                DueDate = requestModel.DueDate,
                Completed = requestModel.Completed,
                Remarks = requestModel.Remarks
            };
            var createdTask = await _historyRepository.AddAsync(t);
            var response = new HistoryResponseModel
            {
                TaskId = createdTask.TaskId,
                UserId = createdTask.UserId,
                Title = createdTask.Title,
                Completed = createdTask.Completed,
                Description = createdTask.Description,
                DueDate = createdTask.DueDate,
                Remarks = createdTask.Remarks
            };
            return response;
        }

        public async System.Threading.Tasks.Task UpdateHistory(int id, HistoryRequestModel requestModel)
        {
            var newHistory = await _historyRepository.GetByIdAsync(id);
            if (newHistory == null)
            {
                throw new Exception("This task does not exist.");
            }
            newHistory.UserId = requestModel.UserId;
            newHistory.Title = requestModel.Title;
            newHistory.Description = requestModel.Description;
            newHistory.DueDate = requestModel.DueDate;
            newHistory.Remarks = requestModel.Remarks;

            await _historyRepository.UpdateAsync(newHistory);
        }

        public async System.Threading.Tasks.Task DeleteHistory(int id)
        {
            var h = await _historyRepository.ListAsync(h => h.TaskId == id);
            await _historyRepository.DeleteAsync(h.First());
        }

    }
}
