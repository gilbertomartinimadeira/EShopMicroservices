var builder = WebApplication.CreateBuilder(args);
var apiAssembly = typeof(Program).Assembly;

// add services to the container
builder.Services.AddCarter();

builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(apiAssembly);    
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

var app = builder.Build();

// configure the request pipeline
app.MapCarter();

app.Run();
