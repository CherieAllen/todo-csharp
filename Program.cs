using Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ITodoItemService, TodoItemService>();

var app = builder.Build();

app.MapGet("/todo-items", () => {});

app.MapGet("/todo-items{id}", async (string id, ITodoItemService todoItemService) => {


    var todoItem = await todoItemService.GetTodoItemById(id);
       
    return Results.Ok(todoItem);


});

app.MapPost("/todo-items", () => {});
app.MapPut("/todo-items/{id}", (string id) => {});
app.MapDelete("/todo-items/{id}", (string id) => {});

app.Run();
