using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Identity;
using Gymbokning.Models;

namespace Gymbokning.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DbSet<GymClass> GymClasses => Set<GymClass>();
        public DbSet<ApplicationUserGymClass> AppUserGyms => Set<ApplicationUserGymClass>();
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //FluentAPI
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ApplicationUserGymClass>()
            .HasKey(t => new { t.ApplicationUserId, t.GymClassId });
        }
        public  DbSet<GymClass> GymClass => Set<GymClass>();
        //public  DbSet<ApplicationUserGymClass> ApplicationUserGymClass { get; set; }
       
        internal Task FindAsync(string userId, int? id)
        {
            throw new NotImplementedException();
        }
    } 
    

 }