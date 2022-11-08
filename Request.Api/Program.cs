using Benchmark.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();


app.MapGet("/todos", async () =>
{
    var todos = Enumerable.Range(1, 5).Select(index =>
        new ResponseExample
        {
            Completed = true,
            Id = DateTime.Now.Millisecond,
            Title = Guid.NewGuid().ToString(),
            UserId = DateTime.Now.Millisecond,
        });
    await Task.Delay(100);

    return todos;
});

app.Run();