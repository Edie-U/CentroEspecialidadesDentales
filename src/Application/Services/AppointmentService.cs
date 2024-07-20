using System.Threading.Tasks;
using CentroEspecialidadesDentales.Application.Common.Interfaces;
using CentroEspecialidadesDentales.Domain.Entities;

namespace CentroEspecialidadesDentales.Application.Services
{
    public class AppointmentService
    {
        private readonly IEmailService _emailService;

        public AppointmentService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task<bool> BookAppointment(Appointment appointment)
        {
            var emailBody = $"<h1>New Appointment</h1>" +
                            $"<p><strong>Name:</strong> {appointment.Name}</p>" +
                            $"<p><strong>Email:</strong> {appointment.Email}</p>" +
                            $"<p><strong>Phone:</strong> {appointment.Phone}</p>" +
                            $"<p><strong>Address:</strong> {appointment.Address}</p>" +
                            $"<p><strong>Date:</strong> {appointment.Date.ToString("yyyy-MM-dd")}</p>" +
                            $"<p><strong>Time:</strong> {appointment.Time}</p>" +
                            $"<p><strong>Notes:</strong> {appointment.Notes}</p>";

            try
            {
                await _emailService.SendEmailAsync("recipient@example.com", "New Appointment Booking", emailBody);
                return true;
            }
            catch
            {
                // Log the exception
                return false;
            }
        }
    }
}
