using HotelProjectAPI.Data;
using HotelProjectAPI.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// **1. Lägg till CORS-policy**
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin() // Tillåt alla ursprung (du kan specificera domäner om det behövs)
              .AllowAnyHeader() // Tillåt alla headers
              .AllowAnyMethod(); // Tillåt GET, POST, PUT, DELETE osv.
    });
});

// **2. Lägg till DbContext-tjänsten**
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer("Server=localhost;Database=GroupProject;Trusted_Connection=True;Trust Server Certificate=Yes"));

// **3. Lägg till controllers och Swagger**
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// **4. Använd CORS-policy**
app.UseCors("AllowAll");

// **5. Konfigurera Swagger för utvecklingsläge**
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// **6. Redirect HTTP till HTTPS**
app.UseHttpsRedirection();

// **7. Lägg till controller-routing**
app.MapControllers();

// **8. Starta applikationen**
app.Run();
