using System.Threading.Tasks;
using EmailService.Models;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailService.SendGrid
{
    public class SendGridEmailService : EmailService<SendGridSettings>
    {
        public SendGridClient SendGridClient { get; set; }

        protected SendGridEmailService(IOptions<SendGridSettings> options) : base(options)
        {
            SendGridClient = new SendGridClient(Settings.ApiKey);
        }

        public override async Task SendEmailAsync(EmailMessage message)
        {
            SendGridMessage sendGridMessage = new SendGridMessage
            {
                From = new EmailAddress(message.FromAdress, message.FromName),
                Subject = message.Subject,
                PlainTextContent = message.Body,
                HtmlContent = message.Body
            };
            sendGridMessage.AddTo(new EmailAddress(message.ToAddress, message.ToName));
            sendGridMessage.SetClickTracking(Settings.EnableClickTracking, Settings.EnableClickTrackingText);
            await SendGridClient.SendEmailAsync(sendGridMessage).ConfigureAwait(false);
        }
    }
}