using Microsoft.EntityFrameworkCore;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;
using Proj_Ecorush.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<EcoRushDbContext>
(optionsAction: options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnectionString")));
builder.Services.AddScoped<IWalkingCycle, WalkCycleServices>();
builder.Services.AddScoped<IAfforestation, AfforestationServices>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
