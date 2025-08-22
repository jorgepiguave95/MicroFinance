using Accounts.Persistence;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
builder.Services.AddScoped<Accounts.Persistence.AccountRepository>();
builder.Services.AddScoped<Accounts.Services.AccountService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowGateway", p => p
        .WithOrigins(
            "http://clientgateway:3000",
            "http://customers:8080"
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

builder.Services.AddDbContext<AccountsDbContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

// Migración automática
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AccountsDbContext>();
    db.Database.Migrate();
}

app.UseCors("AllowGateway");

app.UseAuthorization();

app.MapControllers();

app.Run();
