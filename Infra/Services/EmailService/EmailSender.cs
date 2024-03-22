using Application.Common.Interfaces.Services;
using Application.Models.Email;
using Domain.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;


namespace Infra.Services.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly string _sendGridApiKey;
        public Secrets _secrets { get; }
        public EmailSender(IOptions<Secrets> secrets)
        {
            _sendGridApiKey = secrets.Value.SendGridApiKey;
            _secrets = secrets.Value;
        }
        public async Task<bool> SendEmailAsync(EmailMessage email)
        {
            var client = new SendGridClient(_sendGridApiKey);
            var to = new EmailAddress(email.To);
            var from = new EmailAddress
            {
                Email = _secrets.FromAddress,
                Name = _secrets.FromName
            };

            var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
            var response = await client.SendEmailAsync(message);

            return response.IsSuccessStatusCode;
        }

        //#pragma warning disable CS1998
        //public async Task<bool> SendEmailAsync(EmailMessage email)
        //{        
        //    return true;
        //}
        //#pragma warning restore CS1998
    }
}
