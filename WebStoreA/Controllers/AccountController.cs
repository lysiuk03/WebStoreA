using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models.Account;
using WebStoreA.Constants;
using WebStoreA.Data.Entities.Identity;
using WebStoreA.Interfaces;
using WebStoreA.Models.Account;

namespace WebStoreA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IJwtTokenService _jwtTokenService;

        public AccountController(UserManager<UserEntity> userManager, IJwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _jwtTokenService = jwtTokenService;
        }




        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                return BadRequest();
            }
            var isAuth = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isAuth)
            {
                return BadRequest();
            }
            var token = await _jwtTokenService.CreateToken(user);
            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return BadRequest("Користувач з такою електронною поштою вже існує.");
            }

            var user = new UserEntity
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email,
                Image = model.Image
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                result = _userManager
                           .AddToRoleAsync(user, Roles.User)
                           .Result;
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}
