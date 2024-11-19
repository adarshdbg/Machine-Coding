using Parking_Lot.SnakeLadder;
using System.Text.Json.Serialization;

 List<Player> PlayerList;
List<Ladder> LadderList = new List<Ladder>();
List<Snake> snakes = new List<Snake>();
PlayerList = new List<Player>()
            {
                new Player("Gaurav", new Position(0,0)),
                new Player("Adarsh", new Position(0,0)),
            };
// Convert snake positions
var snakes1 = new List<(int Head, int Tail)>
            {
                (62, 5), (33, 6), (49, 9), (88, 16),
                (41, 20), (56, 53), (98, 64), (93, 73), (95, 75)
            };

foreach (var snake in snakes1)
{
    Position head = Position.GetPositionFromNumber(snake.Head);
    Position tail = Position.GetPositionFromNumber(snake.Tail);
    snakes.Add(new Snake(head, tail));
}

// Convert ladder positions
var ladders1 = new List<(int Start, int End)>
            {
                (2, 37), (27, 46), (10, 32), (51, 68),
                (61, 79), (65, 84), (71, 91), (81, 100)
            };

foreach (var ladder in ladders1)
{
    Position start = Position.GetPositionFromNumber(ladder.Start);
    Position end = Position.GetPositionFromNumber(ladder.End);
    LadderList.Add(new Ladder(start, end));
}
new Game(PlayerList, LadderList, snakes);




















var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

var app = builder.Build();

var sampleTodos = new Todo[] {
    new(1, "Walk the dog"),
    new(2, "Do the dishes", DateOnly.FromDateTime(DateTime.Now)),
    new(3, "Do the laundry", DateOnly.FromDateTime(DateTime.Now.AddDays(1))),
    new(4, "Clean the bathroom"),
    new(5, "Clean the car", DateOnly.FromDateTime(DateTime.Now.AddDays(2)))
};

var todosApi = app.MapGroup("/todos");
todosApi.MapGet("/", () => sampleTodos);
todosApi.MapGet("/{id}", (int id) =>
    sampleTodos.FirstOrDefault(a => a.Id == id) is { } todo
        ? Results.Ok(todo)
        : Results.NotFound());

app.Run();

public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
