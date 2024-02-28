using SchoolAPI.Shared.Extensions;

namespace SchoolAPI.Business.Interfaces.IServices
{
    public interface IService<T> where T : class
    {
        Task<APIResponse> AddRegisterAsync(T entityDto);
        Task<APIResponse> DeleteRegisterAsync(string id);
        Task<APIResponse> EditRegisterAsync(T entityDto);
        Task<APIResponse> GetAllAsync();
        Task<APIResponse> GetByIdAsync(string id);
    }
}
