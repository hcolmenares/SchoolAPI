using Microsoft.Extensions.DependencyInjection;
using SchoolAPI.Business.Interfaces.IRepositories;
using SchoolAPI.Business.MappingProfiles;
using SchoolAPI.Business.Repositories;
using SchoolAPI.Business.Services;
using SchoolAPI.Shared.Models;

namespace SchoolAPI.Business.DoI
{
    public static class DependencyInjection
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            // Configuración de AutoMapper
            services.AddAutoMapper(typeof(MappingConfig));

            // Configuración de repositorios
            services.AddScoped<IRepository<School>, SchoolRepository>();
            services.AddScoped<IRepository<Professor>, ProfessorRepository>();
            services.AddScoped<IRepository<Course>, CourseRepository>();
            services.AddScoped<IRepository<Student>, StudentRepository>();

            // Configuración de servicios
            services.AddScoped<SchoolService>();
            services.AddScoped<ProfessorService>();
            services.AddScoped<CourseService>();
            services.AddScoped<StudentService>();
        }
    }
}
