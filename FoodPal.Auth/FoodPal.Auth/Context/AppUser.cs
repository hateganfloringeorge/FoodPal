using Microsoft.AspNetCore.Identity;

namespace FoodPal.Auth.Context
{
    public class AppUser: IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
