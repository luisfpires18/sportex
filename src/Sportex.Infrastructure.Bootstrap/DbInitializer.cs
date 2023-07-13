namespace Sportex.Infrastructure.Bootstrap
{
    using AutoFixture;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Sportex.Data.Repository.Contexts;
    using Sportex.Data.Repository.Models;

    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            var fixture = new Fixture();

            try
            {
                SportexDBContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetService<SportexDBContext>();

                //if (!context.Roles.Any())
                //{
                //    context.Roles.AddAsync(new IdentityRole
                //    {
                //        Name = UserRoles.ADMIN,
                //        NormalizedName = UserRoles.ADMIN,
                //    });
                //    context.Roles.AddAsync(new IdentityRole
                //    {
                //        Name = UserRoles.MEMBER,
                //        NormalizedName = UserRoles.MEMBER,
                //    });
                //}
                if (!context.Sports.Any())
                {
                    var sport = fixture
                        .Build<Sport>()
                        .Without(s => s.SportID)
                        .With(s => s.Name, "Ciclismo")
                        .Without(s => s.Activities)
                        .Create();

                    context.Sports.Add(sport);
                }

                context.SaveChanges();

                if (!context.Activities.Any())
                {
                    var activity = new Activity
                    {
                        Name = "s",
                        Location = "s",
                        SportID = context.Sports.FirstOrDefault().SportID
                    };

                    var activities = new List<Activity>
                    {
                        activity,
                    };

                    context.Activities.AddRange(activities);
                }

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw;
            }
        }
    }
}