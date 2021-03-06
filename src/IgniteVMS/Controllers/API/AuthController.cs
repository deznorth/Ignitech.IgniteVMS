using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IgniteVMS.Services.Contracts;
using IgniteVMS.Entities;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;

namespace IgniteVMS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> logger;
        private readonly IAuthService authService;

        public AuthController(
            ILogger<AuthController> logger,
            IAuthService authService
        )
        {
            this.logger = logger;
            this.authService = authService;
        }

        /// <summary>
        /// Logs a user in and returns some user information along with an HTTP-Only cookie that contains a JSON Web Token for authorization
        /// </summary>
        [HttpPost("login")]
        [SwaggerResponse(200, null, typeof(UserResponse))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = await authService.AuthenticateUser(request);

                if (response.Jwt == null) return new UnauthorizedResult();

                HttpContext.Response.Cookies.Append(
                    "jwt",
                    response.Jwt,
                    new CookieOptions
                    {
                        HttpOnly = true
                    });

                return Ok(response.CurrentUser);
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }

        /// <summary>
        /// Creates a new user in the database, this is mainly for use if we need a new admin user
        /// </summary>
        [HttpPost("create")]
        [SwaggerResponse(200, null, typeof(UserResponse))]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
        {
            try
            {
                var createdUser = await authService.CreateUser(request);

                if (createdUser == null) return new BadRequestResult();

                return Ok(createdUser);
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
