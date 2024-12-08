using User_OTP_Verification.Entities;

namespace User_OTP_Verification.Repositories
{
    public interface IOtpRepository
    {
        Task AddOtpAsync(Otp otp);
        Task<Otp> GetOtpByUserIdAsync(Guid userId);
    }
}
