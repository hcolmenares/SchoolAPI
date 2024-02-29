using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SchoolAPI.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolAPI.Data
{
    public class Context : IdentityDbContext<User, IdentityRole, string>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }

        public DbSet<School> schools { get; set; }
        public DbSet<Professor> professors { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Student> students { get; set; }
    }
}
