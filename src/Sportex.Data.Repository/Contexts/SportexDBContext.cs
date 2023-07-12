namespace Sportex.Data.Repository.Contexts
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Sportex.Data.Repository.Model;

    public class SportexDBContext : IdentityDbContext
    {
        public SportexDBContext(DbContextOptions<SportexDBContext> options)
            : base(options)
        {
        }

        //public DbSet<Player> Players { get; set; }
    }
}