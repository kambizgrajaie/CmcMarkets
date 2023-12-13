using CmcMarkets.Backend.Service.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.Service.Tasks
{
    public interface IUserTaskServices
    {
        Task<IEnumerable<UserTaskDto>> GetUserRecentTasks(Guid userId);
    }
}
