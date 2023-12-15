using CmcMarkets.Backend.Core.Entities;
using CmcMarkets.Backend.Persistence.Repositories;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.Persistence.DbContext
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IRepository<UserTask> UserTasks { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            UserTasks = new Repository<UserTask>(_context);
        }

        public ApplicationDbContext DbContext => _context;

        public Task<int> Complete()
        {
            return _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
