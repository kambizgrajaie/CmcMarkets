using CmcMarkets.Backend.Core.Entities;
using CmcMarkets.Backend.Persistence.Repositories;
using System;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        public ApplicationDbContext DbContext { get; }
        IRepository<UserTask> UserTasks { get; }
        Task<int> Complete();
    }
}
