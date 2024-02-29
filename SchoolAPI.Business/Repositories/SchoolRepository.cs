using Microsoft.EntityFrameworkCore;
using SchoolAPI.Business.Interfaces.IRepositories;
using SchoolAPI.Data;
using SchoolAPI.Shared.Models;

namespace SchoolAPI.Business.Repositories
{
    public class SchoolRepository : IRepository<School>
    {
        private readonly Context _context;

        public SchoolRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<School>> GetAll()
        {
            return await _context.schools.ToListAsync();
        }

        public async Task<School> GetById(string id)
        {
            return await _context.schools.FindAsync(id);
        }

        public async Task Create(School entity)
        {
            _context.schools.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(School entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(School entity)
        {
            _context.schools.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}