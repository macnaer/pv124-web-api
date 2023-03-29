using Compass.Core.DTO_s;
using Compass.Core.Services;
using Compass.Core.Validation.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Compass.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> IncertAsync([FromBody] ResiterUserDto model)
        {
            var validator = new RegisterUserValidation();
            var validatinResult = await validator.ValidateAsync(model);
            if(validatinResult.IsValid)
            {
                var result = await _userService.IncertAsync(model);
                return Ok(result);
            }
            return BadRequest(validatinResult.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginUserDto model)
        {
            var validator = new LoginUserValidation();
            var validatinResult = await validator.ValidateAsync(model);
            if (validatinResult.IsValid)
            {
                var result = await _userService.LoginAsync(model);
                return Ok(result);
            }
            return BadRequest(validatinResult.Errors);

        }
    }
}
