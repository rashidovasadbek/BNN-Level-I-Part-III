using N70.Identity.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

await builder.ConfigureAsync();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();