using Microsoft.EntityFrameworkCore;
using SchoolAPI.Business.Interfaces.IRepositories;
using SchoolAPI.Data;
using SchoolAPI.Shared.Models;

namespace SchoolAPI.Business.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private readonly Context _context;
        public StudentRepository (Context context)
        {
            _context = context;
        }

        public async Task Create(Student entity)
        {
            _context.students.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Student entity)
        {
            _context.students.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAll()
        {
            return await _context.students.ToListAsync();
        }

        public async Task<Student> GetById(string id)
        {
            return await _context.students.FindAsync(id);
        }

        public async Task Update(Student entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
