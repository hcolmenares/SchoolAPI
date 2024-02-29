using AutoMapper;
using SchoolAPI.Business.Interfaces.IRepositories;
using SchoolAPI.Business.Interfaces.IServices;
using SchoolAPI.Shared.Dto.ModelsDto;
using SchoolAPI.Shared.Extensions;
using SchoolAPI.Shared.Models;

namespace SchoolAPI.Business.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly IRepository<School> _repository;
        private readonly IMapper _mapper;

        public SchoolService(IRepository<School> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<APIResponse> AddRegisterAsync(SchoolCreateDto entityDto)
        {
            try
            {
                if (entityDto == null)
                {
                    string error = "El registro está vacío.";
                    return new APIResponse { IsSuccessful = false, Errors = new List<string> { error } };
                }
                var entity = _mapper.Map<School>(entityDto);
                entity.Id = Guid.NewGuid().ToString();
                await _repository.Create(entity);
                return new APIResponse { IsSuccessful = true, Result = entity };
            }
            catch (Exception ex)
            {
                return new APIResponse { IsSuccessful = false, Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<APIResponse> DeleteRegisterAsync(string id)
        {
            try
            {
                if (id == null)
                {
                    string error = "Ha ocurrido un error con el registro que desea eliminar.";
                    return new APIResponse { IsSuccessful = false, Errors = new List<string> { error } };
                }
                var entity = await _repository.GetById(id);
                if (entity == null)
                {
                    string error = "El registro que desea eliminar no existe.";
                    return new APIResponse { IsSuccessful = false, Errors = new List<string> { error } };
                }
                await _repository.Delete(entity);
                return new APIResponse { IsSuccessful = true };
            }
            catch (Exception ex)
            {
                return new APIResponse { IsSuccessful = false, Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<APIResponse> EditRegisterAsync(SchoolEditDto entityDto)
        {
            try
            {
                if (entityDto == null)
                {
                    string error = "El registro está vacío.";
                    return new APIResponse { IsSuccessful = false, Errors = new List<string> { error } };
                }
                var entity = await _repository.GetById(entityDto.Id);
                if (entity == null)
                {
                    return new APIResponse { IsSuccessful = false, Errors = new List<string> { "School not found" } };
                }
                _mapper.Map(entityDto, entity);
                await _repository.Update(entity);
                return new APIResponse { IsSuccessful = true, Result = entity };
            }
            catch (Exception ex)
            {
                return new APIResponse { IsSuccessful = false, Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<APIResponse> GetAllAsync()
        {
            try
            {
                var entities = await _repository.GetAll();
                var result = _mapper.Map<List<School>>(entities);
                return new APIResponse { IsSuccessful = true, Result = result };
            }
            catch (Exception ex)
            {
                return new APIResponse { IsSuccessful = false, Errors = new List<string> { ex.Message } };
            }
        }

        public async Task<APIResponse> GetByIdAsync(string id)
        {
            try
            {
                var entity = await _repository.GetById(id);
                if (entity == null)
                {
                    string error = "El registro está vacío.";
                    return new APIResponse { IsSuccessful = false, Errors = new List<string> { error } };
                }
                var result = _mapper.Map<School>(entity);
                return new APIResponse { IsSuccessful = true, Result = result };
            }
            catch (Exception ex)
            {
                return new APIResponse { IsSuccessful = false, Errors = new List<string> { ex.Message } };
            }
        }
    }
}
