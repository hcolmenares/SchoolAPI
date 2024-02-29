using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Business.Services;
using SchoolAPI.Shared.Dto.ModelsDto;

namespace SchoolAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly SchoolService _schoolService;

        public SchoolsController(SchoolService schoolService)
        {
            _schoolService = schoolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _schoolService.GetAllAsync();
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchoolById(string id)
        {
            var response = await _schoolService.GetByIdAsync(id);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SchoolCreateDto createDto)
        {
            var response = await _schoolService.AddRegisterAsync(createDto);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(SchoolEditDto updateDto)
        {
            var response = await _schoolService.EditRegisterAsync(updateDto);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _schoolService.DeleteRegisterAsync(id);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }
    }
}
