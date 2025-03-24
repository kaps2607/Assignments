using System.ComponentModel.DataAnnotations.Schema;

namespace Clinical_Appointment_System.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string PatientId { get; set; } // Foreign key from Identity User
        [ForeignKey("PatientId")]
        public User Patient { get; set; }

        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }

        public DateTime AppointmentDate { get; set; }
        public AppointmentStatus Status { get; set; }
    }

    public enum AppointmentStatus
    {
        Scheduled,
        Completed,
        Canceled
    }
}

