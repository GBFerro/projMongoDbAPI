using Microsoft.Extensions.Options;
using projMongoDbAPI.Config;
using projMongoDbAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration Singleton and AppSetting parameters.
builder.Services.Configure<ProjMDSettings>(builder.Configuration.GetSection("ProjMDSettings"));
builder.Services.AddSingleton<IProjMDSettings>(s => s.GetRequiredService<IOptions<ProjMDSettings>>().Value);
builder.Services.AddSingleton<ClientService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
