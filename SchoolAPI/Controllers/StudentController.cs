using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Business.Services;
using SchoolAPI.Shared.Dto.ModelsDto;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;
        public StudentController(StudentService courseService)
        {
            _studentService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _studentService.GetAllAsync();
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(string id)
        {
            var response = await _studentService.GetByIdAsync(id);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentCreateDto createDto)
        {
            var response = await _studentService.AddRegisterAsync(createDto);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(StudenEditDto updateDto)
        {
            var response = await _studentService.EditRegisterAsync(updateDto);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _studentService.DeleteRegisterAsync(id);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

    }
}
