using UrlShortener.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

var service = new UrlShortenerService();
app.MapPost("/shorten", (string longUrl) =>
{
    var shortCode = service.ShortenUrl(longUrl);
    return Results.Ok($"http://localhost:5065/{shortCode}");
});

app.MapGet("/{code}", (string code) =>
{
    var longUrl = service.GetOriginalUrl(code);
    return longUrl is not null
        ? Results.Redirect(longUrl)
        : Results.NotFound("Short url not found");
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => { options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1"); });
}

app.UseHttpsRedirection();


app.Run();