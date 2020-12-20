using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XinyuLi.TaskManagerSystem.Core.Models.Request;
using XinyuLi.TaskManagerSystem.Core.Models.Response;

namespace XinyuLi.TaskManagerSystem.Core.ServiceInterfaces
{
    public interface IHistoryService
    {
        Task<HistoryResponseModel> CreateHistory(HistoryRequestModel requestModel);
        System.Threading.Tasks.Task UpdateHistory(int id, HistoryRequestModel requestModel);
        Task DeleteHistory(int id);
    }
}
