using Microsoft.EntityFrameworkCore;
using TodoApplicationApi.TodoApplicationApi.Business.Services;
using TodoApplicationApi.TodoApplicationApi.Data.Repository;
using TodoApplicationApi.TodoApplicationApi.DataModel;
using TodoApplicationApi.TodoApplicationApi.Interfaces.Repositories;
using TodoApplicationApi.TodoApplicationApi.Interfaces.TodoInterfaces;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

IConfiguration configuration = configurationBuilder.Build();

string connectionString = configuration.GetConnectionString("MySQLConnection");

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddSingleton(configuration);

builder.Services.AddTransient<TodoInterface, TodoService>();

builder.Services.AddTransient<ITodoRepository, TodoRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



/*
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
*/
