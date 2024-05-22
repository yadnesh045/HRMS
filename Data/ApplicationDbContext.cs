using HRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Supervisor> Supervisor { get; set; }
        public DbSet<Super_Admin> Super_Admins { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Assistant> Assistants { get; set; }

        public DbSet<Position> Positions { get; set; }  

        public DbSet<Assets> Assets { get; set; }   
    }
}
