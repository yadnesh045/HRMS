using HRMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Supervisor> Supervisor { get; set; }
        public DbSet<Super_Admin> Super_Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        public DbSet<Assistant> Assistants { get; set; }

        public DbSet<Position> Positions { get; set; }
        //public DbSet<Position> Positions { get; set; }  

        public DbSet<Assets> Assets { get; set; }



        public DbSet<Roles> Roles { get; set; }

        public DbSet<Rec_Candidate> Candiates { get; set; }

        public DbSet<ShorList> ShortListed_Candiates { get; set; }


        public DbSet<AttendanceTbl> AttendanceTbls { get; set; }

    }
}
