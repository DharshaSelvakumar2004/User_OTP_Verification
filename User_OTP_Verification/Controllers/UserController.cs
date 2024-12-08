using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User_OTP_Verification.DTOs;
using User_OTP_Verification.Services;

namespace User_OTP_Verification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        //register new user
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(UserRequest userRequest)
        {
            var response = await _userService.RegisterUserAsync(userRequest);
            if (!response.Success) return BadRequest(response.Message);
            return Ok(response.Message);
        }

        // verify otp
        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(OtpRequest otpRequest)
        {
            var response = await _userService.VerifyOtpAsync(otpRequest);
            if (!response.Success) return BadRequest(response.Message);
            return Ok(response.Message);
        }
    }
}
