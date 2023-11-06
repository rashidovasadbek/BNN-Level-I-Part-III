using N67.EduCourse.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

await builder.ConfigurAsync();

var app = builder.Build();

await app.ConfigureAsync();

await app.RunAsync();