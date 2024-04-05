var builder = WebApplication.CreateBuilder(args);
var apiAssembly = typeof(Program).Assembly;

// add services to the container
builder.Services.AddCarter();

builder.Services.AddMarten(opts => {
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);    
}).UseLightweightSessions();



builder.Services.AddMediatR(config => {
    config.RegisterServicesFromAssembly(apiAssembly);    
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

var app = builder.Build();

// configure the request pipeline
app.MapCarter();

app.Run();
