using Clinical_Appointment_System.Models;
using System.ComponentModel.DataAnnotations;

namespace Clinical_Appointment_System.ViewModel
{
    public class BookAppointmentViewModel
    {
        public List<Doctor> Doctors { get; set; }
        [Required]
        public int DoctorId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }
        [Required]
        public AppointmentStatus Status { get; set; }
    }
}
