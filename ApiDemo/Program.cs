
var builder = WebApplication.CreateSlimBuilder(args);
var app = builder.Build();

app.MapGet("/api", () =>
{
    return "testing api";
});



app.Run();

