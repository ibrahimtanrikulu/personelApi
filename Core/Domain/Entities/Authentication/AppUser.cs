using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Authentication
{
    public class AppUser : IdentityUser
    {
        public string NameSurname { get; set; }
    }
}
