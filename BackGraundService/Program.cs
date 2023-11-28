using BackGraundService.BackGraundService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<BackGroundHostedService>();
builder.Services.AddHostedService<LifecycleHostesService>();
builder.Services.AddHostedService<BackgroundService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();