var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient();

var port = Environment.GetEnvironmentVariable("GATEWAY_PORT") ?? "8080";

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowGateway", p => p
        .WithOrigins(
            $"http://localhost:{port}"
        )
        .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors("AllowGateway");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
