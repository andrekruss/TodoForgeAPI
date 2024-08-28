using Database;
using Database.Repositories.UserRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddDbContext<TodoForgeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("todo_forge_db")));
    builder.Services.AddTransient<IUserRepository, UserRepository>();
}

var app = builder.Build();
{
    app.UseRouting();
    app.MapControllers();
    app.Run();
}
