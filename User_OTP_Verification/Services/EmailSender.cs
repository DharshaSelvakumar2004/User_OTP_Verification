using MailKit.Net.Smtp;
using MimeKit;
using User_OTP_Verification.Configurations;
using User_OTP_Verification.DTOs;

namespace User_OTP_Verification.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _settings;

        public async Task SendEmailAsync(CreateEmail createEmail, string Email)
        {
            //var email = new MimeMessage();
            //email.From.Add(MailboxAddress.Parse(_settings.EmailFrom));
            //email.To.Add(new MailboxAddress("", createEmail.to));
            //email.Subject = createEmail.subject;
            //email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            //{
            //    Text = createEmail.body
            //};

            //using var smtpClient = new MailKit.Net.Smtp.SmtpClient();
            //await smtpClient.ConnectAsync(_settings.SmtpServer, _settings.SmtpPort, true);
            //await smtpClient.AuthenticateAsync(_settings.EmailFrom, _settings.EmailPassword);
            //await smtpClient.SendAsync(email);
            //await smtpClient.DisconnectAsync(true);

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("nora.gleichner@ethereal.email"));
            email.To.Add(MailboxAddress.Parse(Email));

            email.Subject = createEmail.subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = createEmail.body,
            };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("nora.gleichner@ethereal.email", "UufUaSAWY4wN88J7mZ");
            smtp.Send(email);
            smtp.Disconnect(true);

            
        }


    }
}
