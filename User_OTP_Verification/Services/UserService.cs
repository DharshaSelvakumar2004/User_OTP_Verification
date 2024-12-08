using Azure;
using User_OTP_Verification.DTOs;
using User_OTP_Verification.Entities;
using User_OTP_Verification.Repositories;

namespace User_OTP_Verification.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IOtpRepository _otpRepo;
        private readonly IEmailSender _emailSender;

        public UserService(IUserRepository userRepo, IOtpRepository otpRepo, IEmailSender emailSender)
        {
            _userRepo = userRepo;
            _otpRepo = otpRepo;
            _emailSender = emailSender;
        }

        // register new user with otp
        public async Task<UserResponse> RegisterUserAsync(UserRequest userRequest)
        {
            var existingUser = await _userRepo.GetUserByEmailAsync(userRequest.Email);
            if (existingUser != null)
                return new UserResponse { 
                    Success = false, 
                    Message = "Email already exists."
                };

            var user = new User { 
                Id = Guid.NewGuid(),
                Email = userRequest.Email 
            };
            await _userRepo.AddUserAsync(user);

            var otpCode = new Random().Next(100000, 999999).ToString();
            var otp = new Otp { 
                Id = Guid.NewGuid(),
                Code = otpCode,
                UserId = user.Id
            };
            await _otpRepo.AddOtpAsync(otp);

           var createMail = new CreateEmail
            {
                to = user.Email.ToString(),
                subject = "Your OTP Code",
                body = $"Your OTP is: {otpCode}"

            };

            //await _emailSender.SendEmailAsync(user.Email, "Your OTP Code", $"Your OTP is: {otpCode}");
            await _emailSender.SendEmailAsync(createMail,userRequest.Email);
            return new UserResponse {
                Success = true,
                Message = "User registered and OTP sent."
            };
        }

        // verify otp
        public async Task<UserResponse> VerifyOtpAsync(OtpRequest otpRequest)
        {
            var otpRecord = await _otpRepo.GetOtpByUserIdAsync(otpRequest.UserId);
            if (otpRecord == null || otpRecord.Code != otpRequest.Otp)
                return new UserResponse { Success = false, Message = "Invalid OTP." };

            return new UserResponse { Success = true, Message = "OTP verified successfully." };
        }

    }
}
