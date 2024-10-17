using FreightFinder.Application.IoC;
using BuildingBlocks.Logger.Configurations;
using BuildingBlocks.Logger.Enums;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplication();
builder.Services.AddSwaggerGen();

//Logger
builder.Services
    .AddBuildinBlocksLogging()
    .SetLogLevel(BBLogLevel.Information)
    .UseObfuscateSensiteData()
    .WithConsoleOutput();

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
