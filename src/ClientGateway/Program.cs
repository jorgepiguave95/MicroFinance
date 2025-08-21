var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddHttpClient("customers", c =>
    c.BaseAddress = new Uri(Environment.GetEnvironmentVariable("CUSTOMERS_BASEURL")!));
builder.Services.AddHttpClient("accounts", c =>
    c.BaseAddress = new Uri(Environment.GetEnvironmentVariable("ACCOUNTS_BASEURL")!));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//Proxies
app.MapGet("/api/customers/{id}", async (string id, IHttpClientFactory f) =>
{
    var http = f.CreateClient("customers");
    var r = await http.GetAsync($"/api/customers/{id}");
    return Results.Content(await r.Content.ReadAsStringAsync(), "application/json");
});

app.MapGet("/api/accounts/{id}", async (string id, IHttpClientFactory f) =>
{
    var http = f.CreateClient("accounts");
    var r = await http.GetAsync($"/api/accounts/{id}");
    return Results.Content(await r.Content.ReadAsStringAsync(), "application/json");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
