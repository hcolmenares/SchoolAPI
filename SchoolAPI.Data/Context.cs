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
    }
}
