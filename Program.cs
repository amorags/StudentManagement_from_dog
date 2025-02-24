using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DefaultNamespace;

var builder = WebApplication.CreateBuilder(args);

// Add database context with configuration from `appsettings.json`
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.Run();