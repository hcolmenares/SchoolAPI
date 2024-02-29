using Microsoft.EntityFrameworkCore;
using SchoolAPI.Business.Interfaces.IRepositories;
using SchoolAPI.Data;
using SchoolAPI.Shared.Models;

namespace SchoolAPI.Business.Repositories
{
    public class CourseRepository : IRepository<Course>
    {
        private readonly Context _context;
        public CourseRepository(Context context)
        {
            _context = context;
        }

        public async Task Create(Course entity)
        {
            _context.courses.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Course entity)
        {
            _context.courses.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAll()
        {
            return await _context.courses.ToListAsync();
        }

        public async Task<Course> GetById(string id)
        {
            return await _context.courses.FindAsync(id);
        }

        public async Task Update(Course entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
