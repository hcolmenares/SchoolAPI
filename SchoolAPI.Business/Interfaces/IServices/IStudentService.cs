using SchoolAPI.Shared.Dto.ModelsDto;
using SchoolAPI.Shared.Extensions;

namespace SchoolAPI.Business.Interfaces.IServices
{
    public interface IStudentService
    {
        Task<APIResponse> AddRegisterAsync(StudentCreateDto entityDto);
        Task<APIResponse> DeleteRegisterAsync(string id);
        Task<APIResponse> EditRegisterAsync(StudenEditDto entityDto);
        Task<APIResponse> GetAllAsync();
        Task<APIResponse> GetByIdAsync(string id);
    }
}
