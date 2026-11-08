using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using TodoApi.Data;
using TodoApi.Services;

var builder = WebApplication.CreateBuilder(args); //prep webapp

builder.Services.AddControllers();

// get the MySQL connection settings and set up EF Core to use them
var connectionString = builder.Configuration.GetConnectionString("TodoDatabase")
    ?? throw new InvalidOperationException("Connection string 'TodoDatabase' was not found.");

builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseMySQL(connectionString));

builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var app = builder.Build();//create

app.MapControllers();

app.Run();