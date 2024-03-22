using Application.Models.Email;
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
            var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new[]
            {
                new KeyValuePair<string, string>("SendGridApiKey", "apiKey"),
            })
            .Build();

            var emailSettings = Options.Create(new EmailSettings
            {
                FromAddress = "from@example.com",
                FromName = "From Name"
            });

            var email = new EmailMessage
            {
                To = "to@example.com",
                Subject = "Test Email",
                Body = "This is a test email"
            };

            var emailSender = new EmailSender(configuration, emailSettings);

            // Act
            var result = await emailSender.SendEmailAsync(email);

            // Assert
            Assert.True(result);
        }
    }
}
