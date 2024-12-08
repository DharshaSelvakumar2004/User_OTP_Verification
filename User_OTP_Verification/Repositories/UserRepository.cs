using Microsoft.EntityFrameworkCore;
using User_OTP_Verification.Context;
using User_OTP_Verification.Entities;

namespace User_OTP_Verification.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        // get user by email
        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await appDbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        //add new user
        public async Task AddUserAsync(User user)
        {
            appDbContext.Users.Add(user);
            await appDbContext.SaveChangesAsync();
        }
    }
}
