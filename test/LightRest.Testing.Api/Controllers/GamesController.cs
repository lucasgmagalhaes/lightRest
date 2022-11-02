using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace LightRest.Testing.Api;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly List<Game> _games;

    public GamesController()
    {
        _games = new List<Game>
        {
            new Game
            {
                Id = 1,
                Title = "elden ring",
            }
        };
    }

    [HttpGet("{id}")]
    public Game Get([FromRoute] int id)
    {
        return _games[id - 1];
    }

    [HttpPost]
    public Game Post([FromBody] Game game)
    {
        game.Id = _games.Count + 1;
        _games.Add(game);
        return game;
    }


    [HttpPut("{id}")]
    public Game Put([FromBody] Game game, [FromRoute] int id)
    {
        game.Id = id;
        var gameToUpdate = _games.ElementAt(id - 1);

        if (gameToUpdate is not null)
            _games[id - 1] = game;

        return game;
    }

    [HttpDelete("{id}")]
    public Game Delete([FromRoute] int id)
    {
        var removed = _games[id - 1];
        return removed;
    }

    [HttpPatch]
    [Route("{id:int}")]
    public Game Patch(int id)
    {
        return _games[id - 1];
    }

    [HttpHead("{id}")]
    public void Head([FromRoute] int id)
    {
        Response.ContentLength = JsonSerializer.Serialize(_games[id - 1]).Length;
    }
}
