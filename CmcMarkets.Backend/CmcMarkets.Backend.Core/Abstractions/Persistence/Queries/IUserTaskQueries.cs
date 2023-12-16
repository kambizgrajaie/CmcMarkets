using CmcMarkets.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.Core.Abstractions.Persistence.Queries
{
    public interface IUserTaskQueries
    {
        Task<IEnumerable<UserTask>> GetCompletedTasksDuringLastWeek(Guid userId);
    }
}
