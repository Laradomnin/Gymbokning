using Microsoft.AspNetCore.Identity;

namespace Gymbokning.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Id { get; set; }
        public ICollection<ApplicationUserGymClass>? AttendedClasses { get; set; }
    }
}
