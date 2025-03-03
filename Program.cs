using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Models;

var builder = WebApplication.CreateBuilder(args);

// Add database context with configuration from `appsettings.json`
builder.Services.AddDbContext<StudentManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.Run();