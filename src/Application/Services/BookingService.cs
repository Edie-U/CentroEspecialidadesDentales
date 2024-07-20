using CentroEspecialidadesDentales.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentroEspecialidadesDentales.Application.Services
{
    public class BookingService
    {
        private readonly IEmailService _emailService;

        public BookingService(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public async Task SendBookingConfirmationAsync(string email, string subject, string message)
        {
            await _emailService.SendEmailAsync(email, subject, message);
        }
    }
}
