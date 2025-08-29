var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/oi", () => "olá!");
app.MapPost("/oi",()=>"Funcionalidade com POST");

app.Run();
