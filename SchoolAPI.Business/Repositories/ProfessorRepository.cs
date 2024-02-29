using Microsoft.EntityFrameworkCore;
using SchoolAPI.Business.Interfaces.IRepositories;
using SchoolAPI.Data;
using SchoolAPI.Shared.Models;

namespace SchoolAPI.Business.Repositories
{
    public class ProfessorRepository : IRepository<Professor>
    {
        private readonly Context _context;
        public ProfessorRepository(Context context) 
        {
            _context = context;
        }

        public async Task Create(Professor entity)
        {
            _context.professors.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Professor entity)
        {
            _context.professors.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Professor>> GetAll()
        {
            return await _context.professors.ToListAsync();
        }

        public async Task<Professor> GetById(string id)
        {
            return await _context.professors.FindAsync(id);
        }

        public async Task Update(Professor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
