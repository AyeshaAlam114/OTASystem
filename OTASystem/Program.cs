using Microsoft.EntityFrameworkCore;
using OTASystem.Data;
using OTASystem.Data.Models;
using OTASystem.Repositories;
using OTASystem.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseInMemoryDatabase("UserDb")); // Use In-Memory Database

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// **Manually Seed Data**
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    SeedDatabase(context);
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



// **Method to Seed Data**
void SeedDatabase(ApplicationDbContext context)
{
    if (!context.Users.Any()) // Check if users exist before adding
    {
        context.Users.Add(new User
        {
            Id = 1,
            Username = "testuser",
            PasswordHash = "123456", // Use hashing in real apps
            Email = "test@example.com",
            Role = "User"
        });

        context.SaveChanges();
    }
}