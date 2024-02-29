using SchoolAPI.Shared.Dto.ModelsDto;
using SchoolAPI.Shared.Extensions;

namespace SchoolAPI.Business.Interfaces.IServices
{
    public interface ISchoolService
    {
        Task<APIResponse> AddRegisterAsync(SchoolCreateDto entityDto);
        Task<APIResponse> DeleteRegisterAsync(string id);
        Task<APIResponse> EditRegisterAsync(SchoolEditDto entityDto);
        Task<APIResponse> GetAllAsync();
        Task<APIResponse> GetByIdAsync(string id);
    }
}
