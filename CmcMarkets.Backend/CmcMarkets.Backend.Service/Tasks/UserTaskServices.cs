using AutoMapper;
using CmcMarkets.Backend.Core.Abstractions.Services.Tasks;
using CmcMarkets.Backend.Core.Exceptions;
using CmcMarkets.Backend.Core.Dto;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CmcMarkets.Backend.Core.Abstractions.Persistence.Queries;

namespace CmcMarkets.Backend.Service.Tasks
{
    public class UserTaskServices : IUserTaskServices
    {
        private readonly ILogger<UserTaskServices> _logger;
        private readonly IUserTaskQueries _userTaskQueries;
        private readonly IMapper _mapper;

        public UserTaskServices(IUserTaskQueries userTaskQueries,
            IMapper mapper,
            ILogger<UserTaskServices> logger)
        {
            _userTaskQueries = userTaskQueries;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<UserTaskDto>> GetUserRecentTasks(Guid userId)
        {
            _logger.LogDebug($"getting recent tasks for user id {userId}");

            var result = (await _userTaskQueries.GetCompletedTasksDuringLastWeek(userId)).ToList();
            if (!result.Any())
                throw new NotFoundException("No task was found for the current user");

            _logger.LogDebug($"total {result.Count} task found!");
            return _mapper.Map<IEnumerable<UserTaskDto>>(result);
        }
    }
}
