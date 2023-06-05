using ICA.Models;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace ICA.Services
{
    public class MailingService : IMailingService
    {
        private readonly MailSettings _mailSettings;


        public MailingService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;

        }

        public async Task<bool> SendEmailAsync(string mailTo, string subject, string body)
        {
            try
            {

                var email = new MimeMessage
                {
                    Sender = MailboxAddress.Parse(_mailSettings.Email),
                    Subject = subject
                };

                email.To.Add(MailboxAddress.Parse(mailTo));

                var builder = new BodyBuilder();

           

                builder.HtmlBody = body;
                email.Body = builder.ToMessageBody();
                email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Email));

                using var smtp = new SmtpClient();

                smtp.Connect(_mailSettings.Host, _mailSettings.Port);
                smtp.Authenticate(_mailSettings.Email, _mailSettings.Password);
                await smtp.SendAsync(email);

                smtp.Disconnect(true);
                return true;
            }
            catch (Exception e)
            {
                return false;

            }

        }
    }
}
