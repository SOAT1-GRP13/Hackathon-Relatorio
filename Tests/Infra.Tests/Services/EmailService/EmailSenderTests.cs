using Application.Models.Email;
using Domain.Configuration;
using Infra.Services.EmailService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;


namespace Infra.Tests.Services.EmailService
{
    public class EmailSenderTests
    {
        [Fact]
        public async Task SendEmailAsync_Should_Return_True()
        {
            // Arrange
            var emailSettings = Options.Create(new Secrets
            {
                FromAddress = "from@example.com",
                FromName = "From Name",
                SendGridApiKey = "dummyKey"
            });

            var email = new EmailMessage
            {
                To = "to@example.com",
                Subject = "Test Email",
                Body = "This is a test email"
            };

            var emailSender = new EmailSender(emailSettings);

            // Act
            var result = await emailSender.SendEmailAsync(email);

            // Assert
            Assert.True(result);
        }
    }
}
