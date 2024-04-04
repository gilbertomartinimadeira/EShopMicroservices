using Carter;

var builder = WebApplication.CreateBuilder(args);

// add services to the container
builder.Services.AddCarter();

var app = builder.Build();

// configure the request pipeline
app.MapCarter();

app.Run();
