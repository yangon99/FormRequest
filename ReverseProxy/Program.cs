using Exceptionless;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// add http context, so that exceptionless can log http info
builder.Services.AddHttpContextAccessor();

// add yarp
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

// add exceptionless log provider£¬and servier
builder.Logging.AddExceptionless();
builder.Services.AddExceptionless(builder.Configuration, opt => { opt.IncludePostData = true; });

var app = builder.Build();

//app.UseHttpLogging();
app.MapReverseProxy();

app.UseAuthorization();
app.UseExceptionless(app.Services.GetService<ExceptionlessClient>() ?? ExceptionlessClient.Default);

app.MapControllers();

app.Run();
