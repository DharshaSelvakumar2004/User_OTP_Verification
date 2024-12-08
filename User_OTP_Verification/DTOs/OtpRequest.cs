namespace User_OTP_Verification.DTOs
{
    public class OtpRequest
    {
        public Guid UserId { get; set; }
        public string Otp { get; set; }
    }
}
