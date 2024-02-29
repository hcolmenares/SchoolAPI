using SchoolAPI.Shared.Dto.ModelsDto;
using SchoolAPI.Shared.Extensions;

namespace SchoolAPI.Business.Interfaces.IServices
{
    public interface ICourseService
    {
        Task<APIResponse> AddRegisterAsync(CourseCreateDto entityDto);
        Task<APIResponse> DeleteRegisterAsync(string id);
        Task<APIResponse> EditRegisterAsync(CourseEditDto entityDto);
        Task<APIResponse> GetAllAsync();
        Task<APIResponse> GetByIdAsync(string id);
    }
}
