using CmcMarkets.Backend.Core.Entities;
using CmcMarkets.Backend.Core.Enums;
using CmcMarkets.Backend.Persistence.DbContext;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.Tests.TestHarness
{
    public class SeedService : ISeedService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public SeedService(
            ApplicationDbContext dbContext,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IUnitOfWork unitOfWork)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
        }

        public async Task SeedUsersAndRoles()
        {
            string[] roleNames = { "Admin", "User" };

            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);

                // If the role doesn't exist, create it
                if (!roleExist)
                {
                    roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            IdentityUser adminUser = new IdentityUser
            {
                UserName = "admin@example.com",
                Email = "admin@example.com",
            };

            string adminPassword = "Admin@123";

            IdentityUser regularUser = new IdentityUser
            {
                UserName = "user@example.com",
                Email = "user@example.com",
            };

            string regularUserPassword = "User@123";

            // Create users with roles
            if (await _userManager.FindByEmailAsync(adminUser.Email) == null)
            {
                var result = await _userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            if (await _userManager.FindByEmailAsync(regularUser.Email) == null)
            {
                var result = await _userManager.CreateAsync(regularUser, regularUserPassword);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(regularUser, "User");
                }
            }
        }

        public async Task SeedUserTasks()
        {
            Random random = new Random();

            var userIds = _dbContext.Users.Select(u => new Guid(u.Id)).ToList();
            if (!userIds.Any())
            {
                throw new Exception("No users and roles defined. Cannot seed user tasks data!");
            }

            for (int i = 0; i < 10000; i++)
            {
                var userId = userIds[random.Next(userIds.Count)];

                var userTask = new UserTask
                {
                    UserTaskId = Guid.NewGuid(),
                    UserId = userId,
                    Title = "some title",
                    TaskStatus = (TaskStatusEnum)random.Next(0, 2), // 0 or 1 for Incomplete or Completed
                    CreatedAtUtc = DateTime.UtcNow.AddMinutes(-random.Next(1, 365 * 24 * 60)) // Random date within the last year
                };

                await _unitOfWork.UserTasks.Add(userTask);
            }

            await _unitOfWork.Complete();
        }
    }
}
