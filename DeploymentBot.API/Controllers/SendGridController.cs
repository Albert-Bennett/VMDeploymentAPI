using DeploymentBot.API.Controllers.Abstractions;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace DeploymentBot.API.Controllers
{
    public class SendGridController : ISendGridController
    {
        readonly string apiKey;

        public SendGridController()
        {
            apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
        }

        public async Task SendFailedCreationErrorEmail(string vmName, string emailAddress)
        {
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(Environment.GetEnvironmentVariable("SENDGRID_FROM_ADDRESS"), Constants.VMBotName);
            var subject = Constants.FailedVMDeploymentEmailSubject;
            var to = new EmailAddress(emailAddress);
            var plainTextContent = Constants.FailedVMDeploymentMessage(vmName);
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, string.Empty);

            await client.SendEmailAsync(msg);
        }
    }
}
