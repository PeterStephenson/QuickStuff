using QuickStuff;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddSingleton<IDatabaseHelloWorldReader, SqlDatabaseHelloWorldReader>();
var app = builder.Build();
app.MapControllers();
app.Run();

public partial class Program {}