var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();
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


var app = builder.Build();

app.UseCors("AllowGateway");

app.UseAuthorization();

app.MapControllers();

app.Run();
