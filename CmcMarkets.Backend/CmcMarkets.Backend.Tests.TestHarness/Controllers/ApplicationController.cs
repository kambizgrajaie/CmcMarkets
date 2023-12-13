using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.Tests.TestHarness.Controllers
{
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ILogger<ApplicationController> _logger;
        private readonly ISeedService _seedService;

        public ApplicationController(
            ILogger<ApplicationController> logger,
            ISeedService seedService)
        {
            _logger = logger;
            _seedService = seedService;
        }

        [HttpPost]
        [Route("seedUsersAndRoles")]
        public async Task<IActionResult> SeedUsersAndRoles()
        {
            await _seedService.SeedUsersAndRoles();
            return Ok();
        }

        [HttpPost]
        [Route("seedUserTasks")]
        public async Task<IActionResult> SeedUserTasks()
        {
            await _seedService.SeedUserTasks();
            return Ok();
        }
    }
}
