using Microsoft.AspNetCore.Identity;

namespace Clinical_Appointment_System.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
