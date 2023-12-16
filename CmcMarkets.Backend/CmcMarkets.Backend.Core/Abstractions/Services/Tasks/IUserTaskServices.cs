using CmcMarkets.Backend.Core.Dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.Core.Abstractions.Services.Tasks
{
    public interface IUserTaskServices
    {
        Task<IEnumerable<UserTaskDto>> GetUserRecentTasks(Guid userId);
    }
}
