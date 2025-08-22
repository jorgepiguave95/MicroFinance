using Customers.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<Customers.Persistence.CustomerRepository>();
builder.Services.AddScoped<Customers.Services.CustomerService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowGateway", p => p
        .WithOrigins(
            "http://clientgateway:3000",
            "http://accounts:8080"
        )
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
var dbPort = Environment.GetEnvironmentVariable("DB_PORT");
var dbUser = Environment.GetEnvironmentVariable("DB_USER");
var dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");
var dbName = Environment.GetEnvironmentVariable("DB_NAME");

var connectionString = $"Server={dbHost},{dbPort};Database={dbName};User={dbUser};Password={dbPassword};TrustServerCertificate=true;";

builder.Services.AddDbContext<CustomersDbContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

// Migración automática
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<CustomersDbContext>();
    db.Database.Migrate();
}

app.UseCors("AllowGateway");

app.UseAuthorization();

app.MapControllers();

app.Run();
