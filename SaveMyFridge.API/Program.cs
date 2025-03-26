using System;
using Microsoft.EntityFrameworkCore;
using SaveMyFridge.API.Data;
using SaveMyFridge.Data;

var builder = WebApplication.CreateBuilder(args);

// Register the database context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register other services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    DataSeeder.SeedDatabase(context);
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
