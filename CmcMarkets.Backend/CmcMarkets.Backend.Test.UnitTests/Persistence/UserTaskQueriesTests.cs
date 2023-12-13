using CmcMarkets.Backend.Core.Entities;
using CmcMarkets.Backend.Core.Enums;
using CmcMarkets.Backend.Persistence;
using CmcMarkets.Backend.Persistence.Queries;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.Test.UnitTests.Persistence
{
    [TestClass]
    public class UserTaskQueriesTests
    {
        private UserTaskQueries _userTaskQueries;
        private ApplicationDbContext _dbContext;

        [TestInitialize]
        public void Initialize()
        {
            // Mock ApplicationDbContext
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InMemoryDatabase")
                .Options;

            _dbContext = new ApplicationDbContext(dbContextOptions);
            _userTaskQueries = new UserTaskQueries(_dbContext);
        }

        [TestMethod]
        public async Task GetCompletedTasksDuringLastWeek_ShouldReturnCompletedTasks()
        {
            // Arrange
            var userId = Guid.NewGuid();

            // Add test data to the in-memory database
            var tasks = new List<UserTask>
            {
                new UserTask { UserId = userId, TaskStatus = TaskStatusEnum.Completed, CreatedAtUtc = DateTime.UtcNow.AddDays(-5) },
                new UserTask { UserId = userId, TaskStatus = TaskStatusEnum.Completed, CreatedAtUtc = DateTime.UtcNow.AddDays(-6) },
                new UserTask { UserId = userId, TaskStatus = TaskStatusEnum.Incomplete, CreatedAtUtc = DateTime.UtcNow.AddDays(-7) },
            };

            _dbContext.UserTasks.AddRange(tasks);
            _dbContext.SaveChanges();

            // Act
            var result = await _userTaskQueries.GetCompletedTasksDuringLastWeek(userId);

            // Assert
            Assert.AreEqual(2, result.Count()); // Assuming two completed tasks in the last week
        }
    }
}
