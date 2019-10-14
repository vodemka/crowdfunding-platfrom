using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdfundingPlatform.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(email, "Vodemka");
            var sub = "Activate your email please";
            var to = new EmailAddress(email, "Vodemka");
            var plainTextContent = "Verification";
            var htmlContent = message;
            var msg = MailHelper.CreateSingleEmail(from, to, sub, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
