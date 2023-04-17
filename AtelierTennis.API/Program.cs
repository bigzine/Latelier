using AtelierTennis.API.Data;
using AtelierTennis.API.Options;
using AtelierTennis.API.Services;
using AtelierTennis.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services);
builder.Services.Configure<PlayerDataOptions>(builder.Configuration.GetSection("PlayerData"));


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseExceptionHandler("/error");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddTransient<IPlayersService, PlayersService>();
    services.AddTransient<IPlayerDataProvider,FsPlayerDataProvider>();

}