using System.ComponentModel.DataAnnotations;

namespace Clinical_Appointment_System.Models
{
    public class ContactViewModel
    {
        [Required, Display(Name = "Your Name")]
        public string Name { get; set; }

        [Required, EmailAddress, Display(Name = "Your Email")]
        public string Email { get; set; }

        [Required, Display(Name = "Message")]
        public string Message { get; set; }
    }
}
