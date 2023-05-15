using Compass.Core.Interfaces;
using Compass.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Compass.Api.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _coursesService;
        public CourseController(ICourseService coursesService)
        {
            _coursesService = coursesService;
        }

        [AllowAnonymous]
        [HttpGet("courses")]
        public async Task<IActionResult> Index()
        {   
            return Ok(await _coursesService.GetAll());
        }
    }
}
