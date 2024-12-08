using MimeKit;
using MailKit.Net.Smtp;
using User_OTP_Verification.Configurations;

namespace User_OTP_Verification.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _settings;

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_settings.EmailFrom));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart("html") { Text = body };

            using var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(_settings.SmtpServer, _settings.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);
            await smtpClient.AuthenticateAsync(_settings.EmailFrom, _settings.EmailPassword);
            await smtpClient.SendAsync(email);
            await smtpClient.DisconnectAsync(true);
        }
    }
}
