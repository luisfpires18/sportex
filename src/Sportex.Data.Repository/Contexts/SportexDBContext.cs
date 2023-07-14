namespace Sportex.Data.Repository.Contexts
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Sportex.Data.Repository.Model;
    using Sportex.Data.Repository.Models;

    public class SportexDBContext : IdentityDbContext
    {
        public SportexDBContext(DbContextOptions<SportexDBContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }

        public DbSet<Sport> Sports { get; set; }
        
        public DbSet<Activity> Activities { get; set; }
        
        public DbSet<Category> Categories { get; set; }
        
        public DbSet<Competition> Competitions { get; set; }
        
        public DbSet<Athlete> Athletes { get; set; }
        
        public DbSet<Team> Teams { get; set; }
        
        public DbSet<Management> Managements { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        public DbSet<Trophy> Trophies { get; set; }

        public DbSet<Result> Results { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Extra> Extras { get; set; }
    }
}