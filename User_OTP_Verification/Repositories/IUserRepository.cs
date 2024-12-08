using User_OTP_Verification.Entities;

namespace User_OTP_Verification.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
    }
}
