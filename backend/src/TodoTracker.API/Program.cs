

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;
var configuration = builder.Configuration;

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();