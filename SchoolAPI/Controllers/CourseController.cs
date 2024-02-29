using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Business.Services;
using SchoolAPI.Shared.Dto.ModelsDto;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;
        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _courseService.GetAllAsync();
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(string id)
        {
            var response = await _courseService.GetByIdAsync(id);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourseCreateDto createDto)
        {
            var response = await _courseService.AddRegisterAsync(createDto);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CourseEditDto updateDto)
        {
            var response = await _courseService.EditRegisterAsync(updateDto);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _courseService.DeleteRegisterAsync(id);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }
    }
}
