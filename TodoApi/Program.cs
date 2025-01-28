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


var app = builder.Build();

// Exception handling middleware
app.UseExceptionHandler("/error");

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers(); 

app.Run();
