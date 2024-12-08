using Microsoft.EntityFrameworkCore;
using User_OTP_Verification.Context;
using User_OTP_Verification.Entities;

namespace User_OTP_Verification.Repositories
{
    public class OtpRepository : IOtpRepository
    {
        private readonly AppDbContext appDbContext;

        public OtpRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        //add otp 
        public async Task AddOtpAsync(Otp otp)
        {
            appDbContext.Otps.Add(otp);
            await appDbContext.SaveChangesAsync();
        }

        // get otp by user Id
        public async Task<Otp> GetOtpByUserIdAsync(Guid userId)
        {
            return await appDbContext.Otps.FirstOrDefaultAsync(o => o.UserId == userId);
        }
    }
}
