using Clinical_Appointment_System.Data;
using Clinical_Appointment_System.Models;
using Clinical_Appointment_System.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Clinical_Appointment_System.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public AppointmentController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var appointments = await _context.Appointments
                .Include(a => a.Doctor)
                .Where(a => a.PatientId == user.Id) // Show only logged-in user's appointments
                .ToListAsync();

            return View(appointments);
        }

        [HttpGet]
        public async Task<IActionResult> Book()
        {
            if(!await IsUserLoggedIn())
                return RedirectToAction("Login", "Account");
            var doctors = await _context.Doctors.ToListAsync();
            var viewModel = new BookAppointmentViewModel
            {
                Doctors = doctors,
                AppointmentDate = DateTime.Now,
                Status = AppointmentStatus.Scheduled
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Book(BookAppointmentViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var appointment = new Appointment
            {
                PatientId = user.Id,
                DoctorId = model.DoctorId,
                AppointmentDate = model.AppointmentDate,
                Status = model.Status
            };

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            // Ensure only the patient who booked can edit it
            var user = await _userManager.GetUserAsync(User);
            if (user == null || appointment.PatientId != user.Id)
            {
                return Unauthorized(); // Prevent unauthorized access
            }

            var doctors = await _context.Doctors.ToListAsync();

            var viewModel = new BookAppointmentViewModel
            {
                DoctorId = appointment.DoctorId,
                AppointmentDate = appointment.AppointmentDate,
                Status = appointment.Status,
                Doctors = doctors // Populate doctor dropdown
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, BookAppointmentViewModel viewModel)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null || appointment.PatientId != user.Id)
            {
                return Unauthorized();
            }

            // Update the appointment details
            //appointment.DoctorId = viewModel.DoctorId;
            //appointment.AppointmentDate = viewModel.AppointmentDate;
            appointment.Status = viewModel.Status;

            _context.Update(appointment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        //public async Task<IActionResult> Delete(int id)
        //{
        //    var appointment = await _context.Appointments
        //        .Include(a => a.Doctor)
        //        .FirstOrDefaultAsync(a => a.Id == id);

        //    if (appointment == null)
        //    {
        //        return NotFound();
        //    }

        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null || appointment.PatientId != user.Id)
        //    {
        //        return Unauthorized();
        //    }

        //    return View(appointment);
        //}
        [HttpGet]
        [HttpPost]
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null || appointment.PatientId != user.Id)
            {
                return Unauthorized();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        private async Task<bool> IsUserLoggedIn()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return false;
            return true;
        }
    }
}
