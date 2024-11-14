using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Data.Models;

namespace WebApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Module> Modules { get; set; }
        public DbSet<Programme> Programmes { get; set; }
        public DbSet<Staff> Staffing { get; set; }
    }
}
