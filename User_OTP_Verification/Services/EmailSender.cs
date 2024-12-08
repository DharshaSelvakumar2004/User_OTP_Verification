using MailKit.Net.Smtp;
using MimeKit;
using User_OTP_Verification.Configurations;
using User_OTP_Verification.DTOs;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace User_OTP_Verification.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _settings;
        private readonly EmailConfig emailConfig;

        public EmailSender(EmailSettings settings, EmailConfig emailConfig)
        {
            _settings = settings;
            this.emailConfig = emailConfig;
        }

        public async Task SendEmailAsync(CreateEmail createEmail, string Email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailConfig.FromName, emailConfig.FromAddess));
            message.To.Add(new MailboxAddress("", createEmail.to));
            message.Subject = createEmail.subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = createEmail.body,
            };

            using var client = new MailKit.Net.Smtp.SmtpClient();
            client.Connect(emailConfig.SmtpServer, emailConfig.Port, true);
            client.Authenticate(emailConfig.Username, emailConfig.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);


        }


    }
}
