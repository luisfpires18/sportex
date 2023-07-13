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

        public DbSet<Sport> Sports { get; set; }

        public DbSet<Activity> Activities { get; set; }
    }
}