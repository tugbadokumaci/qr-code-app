using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QrCodeApp.Api.ResourceModels;
using QrCodeApp.Api.Services;
using QrCodeApp.ResourceModels;
using QrCodeApp.Shared.Models;

namespace QrCodeApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly JwtService _jwtService;

        public UsersController(
            UserManager<IdentityUser> userManager,
            JwtService jwtService
        )
        {
            _userManager = userManager;
            _jwtService = jwtService;
        }

        // GET: api/Users/username
        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            IdentityUser? user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return NotFound();
            }

            return new User
            {
                UserName = user.UserName!,
                Email = user.Email!
            };
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.CreateAsync(
                new IdentityUser() { UserName = user.UserName!, Email = user.Email! },
                user.Password
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            user.Password = "123";
            return Created("", user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticationResponse>> Login(AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad credentials");
            }

            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null)
            {
                return BadRequest("Bad credentials");
            }

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);

            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }

            var token = _jwtService.CreateToken(user);

            if (token == null)
            {
                return BadRequest("Failed to create token");
            }

            return Ok(token);
        }
    }
}
