using CmcMarkets.Backend.Core.Entities;
using CmcMarkets.Backend.Core.Enums;
using CmcMarkets.Backend.Persistence.DbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.Persistence.Queries
{
    public class UserTaskQueries : IUserTaskQueries
    {
        private ApplicationDbContext _context;

        public UserTaskQueries(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserTask>> GetCompletedTasksDuringLastWeek(Guid userId)
        {
            return await _context.UserTasks
                    .Where(task => task.TaskStatus == TaskStatusEnum.Completed
                                && task.CreatedAtUtc >= DateTime.UtcNow.AddDays(-7)
                                && task.UserId == userId)
                .OrderBy(ut => ut.CreatedAtUtc)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
