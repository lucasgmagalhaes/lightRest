using LightRest.Testing.Api;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

var games = new List<Game>
{
    new Game
    {
        Id = 1,
        Title = "elden ring",
    }
};

app.MapGet("/games", () =>
{
    return games;
});

app.MapPut("/games", ([FromBody] Game game, [FromQuery] int id) =>
{
    game.Id = id;
    games.Add(game);
});

app.MapPost("/games", ([FromBody] Game game) =>
{
    game.Id = games.Count + 1;
    games.Add(game);
});

app.Run();

public partial class Program
{
    protected Program() { }
}