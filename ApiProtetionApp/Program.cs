using ApiProtetionApp.StartUp;
using AspNetCoreRateLimit;
using WatchDog;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();
builder.AddRateLimitServices();
builder.Services.AddWatchDogServices();

var app = builder.Build();

app.UseIpRateLimiting();

app.UseWatchDogExceptionLogger();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseWatchDog(Opts =>
{
    Opts.WatchPageUsername = app.Configuration.GetValue<string>("WatchDogs:UserName");
    Opts.WatchPagePassword = app.Configuration.GetValue<string>("WatchDogs:Password");
});

app.UseResponseCaching();

app.UseAuthorization();

app.MapControllers();


app.Run();
