namespace User_OTP_Verification.Entities
{
    public class Otp
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
