using BSAspExam.API.Core;
using BSAspExam.Models.Common;
using BSAspExam.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace BSAspExam.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly JWTService jwtService;

        public AuthController(UserManager<ApplicationUser> userManager,
            JWTService jwtService)
        {
            this.userManager = userManager;
            this.jwtService = jwtService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, model.Password))
            {
                var userRoles = await userManager.GetRolesAsync(user);

                var tokenRes = jwtService.CreateToken(user, userRoles);

                return Ok(new
                {
                    token = tokenRes.Token,
                    expiration = tokenRes.Expiration
                });
            }
            return Unauthorized();
        }


        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new AppResponse
                {
                    Status = "Error",
                    Message = "User already exists!"
                });

            ApplicationUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new AppResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            return Ok(new AppResponse { Status = "Success", Message = "User created successfully!" });
        }
    }
}
