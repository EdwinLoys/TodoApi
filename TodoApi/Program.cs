using Microsoft.EntityFrameworkCore;
using TodoApi.Data;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------
// Services
// ---------------------------

// Add controllers for API endpoints
builder.Services.AddControllers();

// Configure EF Core with SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Enable CORS (allows frontend to call API)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Add Swagger/OpenAPI for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ---------------------------
// Middleware
// ---------------------------

// Enable CORS
app.UseCors();

// Serve frontend SPA (index.html, CSS, JS)
app.UseDefaultFiles(); // serves index.html automatically
app.UseStaticFiles();  // serves CSS, JS, images, etc.

// Swagger (only in development)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
        c.RoutePrefix = "swagger"; // Swagger available at /swagger
    });
}

// Enable routing for controllers
app.UseAuthorization();
app.MapControllers();

// Run the application
app.Run();
