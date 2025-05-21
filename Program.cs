using MiniTodo.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("v1/todos", (AppDbContext context) =>
{
    var todos = context.ToDos.ToList();
    return Results.Ok(todos);
});
app.MapPost("v1/todos", (AppDbContext context, CreateToDoViewModel model) => {
    var todo = model.MapTo();
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);
    context.ToDos.Add(todo);
    context.SaveChanges();
    return Results.Created($"/v1/todos/{todo.Id}", todo);
});
app.Run();
