// This project will be a minimal yet functional API for a "To-Do List" application
// Goal Requirements: Use .NET 9, C#, Entity Framework Core, and Dependency Injection
// The focus is on clean design, Python-like fast endpoints, and ORM interaction

using Microsoft.EntityFrameworkCore; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseInMemoryDatabase("TodoList"));               // In-memory DB for Testing

builder.Services.AddScoped<ITodoService, TodoService>();    // Dependency Injection
builder.Services.AddControllers(); 

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();    

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Swagger middleware
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
        options.RoutePrefix = string.Empty; // This serves Swagger UI at the root
    });
}

app.UseAuthorization();
app.MapControllers(); 

app.Run();
