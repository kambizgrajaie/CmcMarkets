using CmcMarkets.Backend.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.Persistence.Queries
{
    public interface IUserTaskQueries
    {
        Task<IEnumerable<UserTask>> GetCompletedTasksDuringLastWeek(Guid userId);
    }
}
