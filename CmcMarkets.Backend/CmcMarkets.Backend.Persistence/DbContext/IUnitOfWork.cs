using CmcMarkets.Backend.Core.Abstractions.Persistence.Repositories;
using CmcMarkets.Backend.Core.Entities;
using System;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.Persistence.DbContext
{
    public interface IUnitOfWork : IDisposable
    {
        public ApplicationDbContext DbContext { get; }
        IRepository<UserTask> UserTasks { get; }
        Task<int> Complete();
    }
}
