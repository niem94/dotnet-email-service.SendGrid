using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace EmailService.SendGrid
{
    public class SendGridEmailService : EmailService<SendGridOptions>
    {
        public SendGridClient SendGridClient { get; set; }

        protected SendGridEmailService(IOptions<SendGridOptions> options) : base(options)
        {
            SendGridClient = new SendGridClient(Options.ApiKey);
        }

        public override async Task SendEmailAsync(EmailMessage message)
        {
            SendGridMessage sendGridMessage = new SendGridMessage
            {
                From = new EmailAddress(message.FromAddress, message.FromName),
                Subject = message.Subject,
                PlainTextContent = message.Body,
                HtmlContent = message.Body
            };
            sendGridMessage.AddTo(new EmailAddress(message.ToAddress, message.ToName));
            sendGridMessage.SetClickTracking(Options.EnableClickTracking, Options.EnableClickTrackingText);
            await SendGridClient.SendEmailAsync(sendGridMessage).ConfigureAwait(false);
        }
    }
}