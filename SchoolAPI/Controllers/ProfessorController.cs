using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Business.Services;
using SchoolAPI.Shared.Dto.ModelsDto;

namespace SchoolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        private readonly ProfessorService _professorService;
        public ProfessorController(ProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _professorService.GetAllAsync();
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessorById(string id)
        {
            var response = await _professorService.GetByIdAsync(id);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProfessorCreatedDto createDto)
        {
            var response = await _professorService.AddRegisterAsync(createDto);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProfessorEditDto updateDto)
        {
            var response = await _professorService.EditRegisterAsync(updateDto);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _professorService.DeleteRegisterAsync(id);
            if (response.IsSuccessful)
            {
                return Ok(response.Result);
            }
            return BadRequest(response.Errors);
        }

    }
}
