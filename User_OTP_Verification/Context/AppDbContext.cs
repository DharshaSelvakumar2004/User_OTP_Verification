using Microsoft.EntityFrameworkCore;
using User_OTP_Verification.Entities;

namespace User_OTP_Verification.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Otp> Otps { get; set; }
    }
}
