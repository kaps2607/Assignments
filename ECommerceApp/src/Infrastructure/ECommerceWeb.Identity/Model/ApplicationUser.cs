using Microsoft.AspNetCore.Identity;

namespace ECommerceWeb.Identity.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
