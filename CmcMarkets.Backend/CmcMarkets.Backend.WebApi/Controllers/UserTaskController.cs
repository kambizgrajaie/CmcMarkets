using CmcMarkets.Backend.Core;
using CmcMarkets.Backend.Core.Exceptions;
using CmcMarkets.Backend.Service.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserTaskController : ControllerBase
    {
        private readonly ILogger<UserTaskController> _logger;
        private readonly IUserTaskServices _userTaskServices;

        public UserTaskController(
            ILogger<UserTaskController> logger,
            IUserTaskServices userTaskServices)
        {
            _logger = logger;
            _userTaskServices = userTaskServices;
        }

        [Authorize(Roles=Roles.User)]
        [HttpGet]
        [Route("getRecentTasks")]
        public async Task<IActionResult> GetRecentTasks()
        {
            var userId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            _logger.LogInformation($"Received the request for getting recent tasks for user id {userId}");

            try
            {
                //we inject NameIdentifier claim when logging in and set it to user id
                var res = (await _userTaskServices.GetUserRecentTasks(userId)).ToList();
                _logger.LogInformation($"returning result of recent tasks for user id {userId}. {res.Count} tasks found!");
                return Ok(res);
            }
            catch (ArgumentException ex)
            {
                _logger.LogError($"Exception raised when getting recent tasks for user id {userId}. {ex.Message}");
                return BadRequest($"Bad request: {ex.Message}");
            }
            catch(NotFoundException ex)
            {
                _logger.LogError($"Exception raised when getting recent tasks for user id {userId}. {ex.Message}");
                return NotFound($"Tasks not found: {ex.Message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception raised when getting recent tasks for user id {userId}. {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
