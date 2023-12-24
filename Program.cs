using HotelProjectAPI.Data;
using HotelProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Registering the DbContext (Context) in the service container.
builder.Services.AddDbContext<Context>(
    options => options.UseSqlServer("Server=localhost;Database=GroupProject;Trusted_connection=True;Trust Server Certificate=Yes")
);

var app = builder.Build();

// Configure the HTTP request pipeline.

// Enable Swagger/OpenAPI only in the development environment.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS.

app.MapControllers(); // Map the controllers to the URL routes.

app.Run(); // Start the application.
