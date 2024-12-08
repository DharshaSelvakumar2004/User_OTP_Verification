using MimeKit;
using User_OTP_Verification.Configurations;
using User_OTP_Verification.DTOs;

namespace User_OTP_Verification.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _settings;

        public async Task SendEmailAsync(CreateEmail createEmail)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_settings.EmailFrom));
            email.To.Add(MailboxAddress.Parse(createEmail.to));
            email.Subject = createEmail.subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = createEmail.body 
            };

            using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
            await smtpClient.ConnectAsync(_settings.SmtpServer, _settings.SmtpPort, true);
            await smtpClient.AuthenticateAsync(_settings.EmailFrom, _settings.EmailPassword);
            await smtpClient.SendAsync(email);
            await smtpClient.DisconnectAsync(true);
        }
    }
}
