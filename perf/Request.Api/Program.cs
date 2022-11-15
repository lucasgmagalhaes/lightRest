using Benchmark.Common;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();


app.MapGet("/todos/{toGenerate}", ([FromRoute] int toGenerate) =>
{
    var todos = Enumerable.Range(1, toGenerate).Select(index =>
        new ResponseExample
        {
            Completed = true,
            Id = DateTime.Now.Millisecond,
            Title = Guid.NewGuid().ToString(),
            UserId = DateTime.Now.Millisecond,
        });

    return todos;
});

app.Run();