using CmcMarkets.Backend.Core.Exceptions;
using CmcMarkets.Backend.Core.Model;
using CmcMarkets.Backend.Service.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace CmcMarkets.Backend.Tests.TestHarness.Controllers
{
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly ILogger<AuthenticateController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserAuthenticationServices _authenticationServices;
        private readonly IConfiguration _configuration;

        public AuthenticateController(
            ILogger<AuthenticateController> logger,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IUserAuthenticationServices authenticationServices,
            IConfiguration configuration)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _authenticationServices = authenticationServices;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginModel model)
        {
            try
            {
                var res = await _authenticationServices.Login(model);
                return Ok(new
                {
                    token = res.Token,
                    expiration = res.ValidTo
                });
            } catch (UnAuthorizedException)
            {
                return Unauthorized();
            } catch
            {
                throw;
            }
        }

        [HttpPost]
        [Route("register-user")]
        public async Task<IActionResult> RegisterUser([FromBody] UserRegisterModel model)
        {
            try
            {
                var res = await _authenticationServices.RegisterUser(model);
                return Ok(res);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", ex.Message });
            }
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] UserRegisterModel model)
        {
            try
            {
                var res = await _authenticationServices.RegisterAdmin(model);
                return Ok(res);
            }
            catch (InternalServerErrorException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = "Error", ex.Message });
            }
        }
    }
}
