
using Microsoft.EntityFrameworkCore;
using User_OTP_Verification.Context;
using User_OTP_Verification.DTOs;
using User_OTP_Verification.Repositories;
using User_OTP_Verification.Services;

namespace User_OTP_Verification
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Otp")));
            builder.Services.Configure<EmailConfig>(builder.Configuration.GetSection("EmailConfig"));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IOtpRepository, OtpRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IEmailSender, EmailSender>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
