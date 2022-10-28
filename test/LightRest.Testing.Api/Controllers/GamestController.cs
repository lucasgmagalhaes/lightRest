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

    [HttpGet]
    public List<Game> Get()
    {
        return _games;
    }

    [HttpPost]
    public Game Post([FromBody] Game game)
    {
        game.Id = _games.Count + 1;
        _games.Add(game);
        return game;
    }

    [HttpPost("post-empty")]
    public void PostEmpty()
    {
        // tests
    }

    [HttpPut("post-empty")]
    public void PutEmpty()
    {
        // tests
    }

    [HttpPut("{id}")]
    public void Put([FromBody] Game game, [FromRoute] int id)
    {
        game.Id = id;
        var gameToUpdate = _games.ElementAt(id - 1);

        if (gameToUpdate is not null)
            _games[id - 1] = game;
    }

    [HttpGet("{id}")]
    public void Delete([FromRoute] int id)
    {
        _games.RemoveAt(id - 1);
    }

    [HttpPatch]
    public void Patch([FromBody] Game _)
    {
        //test
    }

    [HttpHead("{id}")]
    public void Head([FromRoute] int id)
    {
        Response.ContentLength = JsonSerializer.Serialize(_games[id - 1]).Length;
    }
}
