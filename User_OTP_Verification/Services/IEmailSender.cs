using User_OTP_Verification.DTOs;

namespace User_OTP_Verification.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(CreateEmail createEmail, string Email);
    }
}
