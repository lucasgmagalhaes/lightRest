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

    [HttpGet]
    public Game Fetch()
    {
        return _games.FirstOrDefault();
    }

    [HttpGet("return-body")]
    public Game GetReturnBody([FromBody] Game game)
    {
        return game;
    }

    [HttpPost]
    public Game Post([FromBody] Game game)
    {
        game.Id = _games.Count + 1;
        _games.Add(game);
        return game;
    }

    [HttpPost("return-body")]
    public Game PostReturnBody([FromBody] Game game)
    {
        return game;
    }

    [HttpPut("return-body")]
    public Game PutReturnBody([FromBody] Game game)
    {
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

    [HttpDelete("return-body")]
    public Game DeleteReturnBody([FromBody] Game game)
    {
        return game;
    }
    
    [HttpHead("return-body")]
    public Game HeadReturnBody([FromBody] Game game)
    {
        return game;
    }

    [HttpPatch]
    [Route("{id:int}")]
    public Game Patch(int id)
    {
        return _games[id - 1];
    }

    [HttpPatch]
    [Route("return-body")]
    public Game PatchReturnBody([FromBody] Game game)
    {
        return game;
    }

    [HttpHead("{id}")]
    public void Head([FromRoute] int id)
    {
        Response.ContentLength = JsonSerializer.Serialize(_games[id - 1]).Length;
    }
}
