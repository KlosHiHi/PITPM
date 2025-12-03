using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xml = $"{Assembly.GetExecutingAssembly().GetName().Name}";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapGet("/hello", (string username) =>
{
    if (string.IsNullOrWhiteSpace(username))
        return Results.BadRequest(new {Error = "Имя пользователя введено некорректно"});

    return Results.Ok(new { Message = $"Привет {username}" });
});

app.MapControllers()
    .WithName("GetWeatherForecast");

app.Run();
