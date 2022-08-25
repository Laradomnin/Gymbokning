using Bogus;
using Gymbokning.Models;
using Microsoft.AspNetCore.Identity;

namespace Gymbokning.Data
{
    public class SeedData
    {
        private static ApplicationDbContext db = default!;
        private static RoleManager<IdentityRole> roleManager = default!;
        private static UserManager<ApplicationUser> userManager= default!;

        public static string Description { get; private set; }

#pragma warning disable IDE0060 // Remove unused parameter
        public static async Task InitAsync (ApplicationDbContext context, IServiceProvider services)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (context is null) throw new ArgumentNullException(nameof (context));
            db=context;
               if (services is null) throw new ArgumentNullException(nameof (services));
            if (context.GymClass.Any()) return;

             roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            //om ej funkar ändra i DbContext        
            ArgumentNullException.ThrowIfNull(roleManager);

            userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            //om ej funkar ändra i DbContext        
            ArgumentNullException.ThrowIfNull(roleManager);
            var roleNames = new[] { "Member", "Admin" };
            var adminEmail = "admin@gym.se";
            var gymClasses = GetGymClasses();

        }
        private static IEnumerable<GymClass> GetGymClasses()
        {
            var faker = new Faker("sv");
            var gymClasses = new List<GymClass>();
            for(int i = 0; i < 20; i++)
            {
                var temp = new GymClass
                {
                Name = faker.Company.CatchPhrase(),
                Description = faker.Hacker.Verb(),
                Duration = new TimeSpan(0,55,0),
                StartTime = DateTime.Now.AddDays(faker.Random.Int(-5,5))
                };
                gymClasses.Add(temp);   
            }
            return gymClasses;
        }
        }

}   