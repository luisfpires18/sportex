namespace Sportex.Infrastructure.Bootstrap
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Sportex.Application.Service;
    using Sportex.Application.Service.Mappers;
    using Sportex.Application.Service.Mappers.Interfaces;
    using Sportex.Data.Repository.Contexts;
    using Sportex.Data.Repository.Implementations;
    using Sportex.Data.Repository.Interfaces;

    public static class DIRegistration
    {
        public static void RegisterDI(WebApplicationBuilder builder)
        {
            RegisterServices(builder);
            RegisterRepositories(builder);
            RegisterMappers(builder);
        }

        public static void RegisterServices(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IPlayerService, PlayerService>();
        }

        public static void RegisterRepositories(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IPlayerRepository, PlayerRepository>();
        }

        public static void RegisterMappers(WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IPlayerMapper, PlayerMapper>();
        }

        public static void RegisterDBContext(
            WebApplicationBuilder builder,
            string connectionString)
        {
            builder.Services.AddDbContext<SportexDBContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<SportexDBContext>();
        }

        public static void RegisterIdentityContext(WebApplicationBuilder builder)
        {
        }
    }
}