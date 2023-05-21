var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/weather", () =>
{
    var weatherForecast = Enumerable.Range(1, 5)
        .Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            Temperature = Random.Shared.Next(-20, 55)
        })
        .ToArray();

    return Results.Ok(weatherForecast);
});

app.Run();

internal record struct WeatherForecast(DateTime Date, int Temperature);
