using E_Commerce_Application.Startup_Extensions;
using App_Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope=app.Services.CreateScope())
{
    var cxt = scope.ServiceProvider.GetService<StoreDbContext>();
    cxt.Database.EnsureCreated();
    cxt.Database.Migrate();
   await StoreDbContext.SeedData(scope.ServiceProvider);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
