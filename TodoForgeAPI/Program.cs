using Database;
using Database.Repositories.BoardRepo;
using Database.Repositories.UserRepo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TodoForgeAPI.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<TodoForgeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("todo_forge_db")));
    builder.Services.AddTransient<IUserRepository, UserRepository>();
    builder.Services.AddTransient<IBoardRepository, BoardRepository>();
    builder.Services.AddSingleton(new JwtService(builder.Configuration["JwtSecretKey"], "TodoForge", "TodoForge"));
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "TodoForge",
            ValidAudience = "TodoForge",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSecretKey"]))
        };
    });
    builder.Services.AddAuthorization();
}

var app = builder.Build();
{
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
