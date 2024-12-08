using User_OTP_Verification.DTOs;

namespace User_OTP_Verification.Services
{
    public interface IUserService
    {
        Task<UserResponse> RegisterUserAsync(UserRequest userRequest);
        Task<UserResponse> VerifyOtpAsync(OtpRequest otpRequest);
    }
}
