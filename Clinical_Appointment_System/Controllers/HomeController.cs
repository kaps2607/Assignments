using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Clinical_Appointment_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clinical_Appointment_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Contact", model);  // Return to Contact page if validation fails
            }

            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("kapillund29@gmail.com", "fxfg trme vamb zuiw"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("kapillund29@gmail.com"),
                    Subject = "New Contact Form Message",
                    Body = $"Name: {model.Name}\nEmail: {model.Email}\nMessage:\n{model.Message}",
                    IsBodyHtml = false,
                };

                mailMessage.To.Add("kapillund29@gmail.com"); // Replace with your email

                smtpClient.Send(mailMessage);

                TempData["SuccessMessage"] = "Your message has been sent successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error sending message. Please try again later.";
                Console.WriteLine("Error: " + ex.Message);
                Console.WriteLine(ex.Message);
            }

            return RedirectToAction("Contact"); // ✅ Redirect to Contact page after submission
        }


        private async Task<bool> SendEmail(string toEmail, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com") // Change SMTP if needed
                {
                    Port = 587,
                    Credentials = new NetworkCredential("kapillund29@gmail.com", "fxfg trme vamb zuiw"),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("kapillund29@gmail.com"),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
