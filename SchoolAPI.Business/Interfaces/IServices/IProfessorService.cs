using SchoolAPI.Shared.Dto.ModelsDto;
using SchoolAPI.Shared.Extensions;

namespace SchoolAPI.Business.Interfaces.IServices
{
    public interface IProfessorService
    {
        Task<APIResponse> AddRegisterAsync(ProfessorCreatedDto entityDto);
        Task<APIResponse> DeleteRegisterAsync(string id);
        Task<APIResponse> EditRegisterAsync(ProfessorEditDto entityDto);
        Task<APIResponse> GetAllAsync();
        Task<APIResponse> GetByIdAsync(string id);
    }
}
