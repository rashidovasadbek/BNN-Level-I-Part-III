using Notifications.Api;

var builder = WebApplication.CreateBuilder(args);

await builder.ConfigureAsync();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
await app.RunAsync();