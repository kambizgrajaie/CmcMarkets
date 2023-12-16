using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CmcMarkets.Backend.Core.Entities;
using CmcMarkets.Backend.Core.Dto;
using CmcMarkets.Backend.Core.Enums;
using CmcMarkets.Backend.Service.Tasks;
using Microsoft.Extensions.Logging;
using CmcMarkets.Backend.Core.Abstractions.Persistence.Queries;

namespace CmcMarkets.Backend.Test.UnitTests.Service
{
    [TestClass]
    public class UserTaskServicesTests
    {
        // Mocked dependencies
        private Mock<IUserTaskQueries> _userTaskQueriesMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ILogger<UserTaskServices>> _logger;
        // Class under test
        private UserTaskServices _userTaskServices;

        [TestInitialize]
        public void Initialize()
        {
            // Mocking dependencies
            _userTaskQueriesMock = new Mock<IUserTaskQueries>();
            _mapperMock = new Mock<IMapper>();
            _logger = new Mock<ILogger<UserTaskServices>>();

            // Creating UserTaskServices with mocked dependencies
            _userTaskServices = new UserTaskServices(_userTaskQueriesMock.Object, _mapperMock.Object, _logger.Object);
        }

        [TestMethod]
        public async Task GetUserRecentTasks_ShouldMapResultsFromQueries()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var completedTasks = new List<UserTask>
            {
                new UserTask { UserId = userId, TaskStatus = TaskStatusEnum.Completed, CreatedAtUtc = DateTime.UtcNow.AddDays(-5) },
                new UserTask { UserId = userId, TaskStatus = TaskStatusEnum.Completed, CreatedAtUtc = DateTime.UtcNow.AddDays(-6) },
                new UserTask { UserId = userId, TaskStatus = TaskStatusEnum.Completed, CreatedAtUtc = DateTime.UtcNow.AddDays(-7) },
            };

            var expectedMappedResult = new List<UserTaskDto>
            {
                new UserTaskDto { UserId = userId, TaskStatus = TaskStatusEnum.Completed, CreatedAtUtc = DateTime.UtcNow.AddDays(-5) },
                new UserTaskDto { UserId = userId, TaskStatus = TaskStatusEnum.Completed, CreatedAtUtc = DateTime.UtcNow.AddDays(-6) },
            };

            _userTaskQueriesMock.Setup(utq => utq.GetCompletedTasksDuringLastWeek(userId))
                .ReturnsAsync(completedTasks);

            _mapperMock.Setup(m => m.Map<IEnumerable<UserTaskDto>>(completedTasks))
                .Returns(expectedMappedResult);

            // Act
            var result = await _userTaskServices.GetUserRecentTasks(userId);

            // Assert
            _userTaskQueriesMock.Verify(utq => utq.GetCompletedTasksDuringLastWeek(userId), Times.Once);
            _mapperMock.Verify(m => m.Map<IEnumerable<UserTaskDto>>(completedTasks), Times.Once);
            CollectionAssert.AreEqual(expectedMappedResult, (List<UserTaskDto>)result);
        }
    }
}
