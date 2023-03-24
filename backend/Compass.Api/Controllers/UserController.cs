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
                if (result.Success)
                {
                    return Ok(result.Message);
                }
                return BadRequest(result.Errors);
            }
            return BadRequest(validatinResult.Errors);
        }
    }
}
