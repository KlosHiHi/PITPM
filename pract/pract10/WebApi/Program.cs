using Microsoft.OpenApi.Models;
using WebApi.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Задачи",
        Version = "v1",
        Description = "API позволяет управлять списком задач.",
        Contact = new OpenApiContact
        {
            Name = "Гидрид Калия",
            Email = "vav420@gmail.com",
            Url = new Uri("https://youtube.com/@kl0shi")
        },
        License = new OpenApiLicense
        {
            Name = "Данное API распространняется по лиценции LGPL-3",
            Url = new Uri("https://ru.wikipedia.org/wiki/GNU_Lesser_General_Public_License")
        }

    });

    var xmlPath = Path.Combine(AppContext.BaseDirectory, "WebApi.xml");
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/health", () =>
{
    Results.Ok(new { Message = $"API работает в штатном режиме" });
})
    .WithName("ShowApi")
    .WithTags("API health")
    .Produces(StatusCodes.Status200OK)
    .WithOpenApi(operation =>
    {
        operation.Summary = "Проверка состояния работы API";
        operation.Description = "Если ответ не получен -> значит API не работает";
        return operation;
    });

app.MapGet("/tasks", static (DateTime start, DateTime end) =>
{
    Random rad = new();
    int num = rad.Next(1, 2);

    if (num == 1)
        return Results.BadRequest();

    return Results.Ok(new TaskModel()
    {
        TaskId = 4,
        Name = "Доставить тюленя",
        Description = "Сейчас он спит.",
        ExecutionTime = new(),
        Status = WebApi.Model.TaskStatus.Running
    });
})
    .WithName("TakeTasks")
    .WithTags("ShowListOgTask")
    .Produces(StatusCodes.Status400BadRequest)
    .WithOpenApi(operation =>
    {
        operation.Summary = "Получение задач внутри временного диапазона";
        operation.Description = "Пишите начальную и конечную дату диапазона, и получаете список задач.";
        operation.Parameters.Add(
            new OpenApiParameter()
            {
                Name = "start",
                Description = "начало диапазона дат"
            });
        operation.Parameters.Add(
            new OpenApiParameter()
            {
                Name = "end",
                Description = "конец диапазона дат"
            });
        return operation;
    });

app.UseAuthorization();

app.MapControllers();

app.Run();
