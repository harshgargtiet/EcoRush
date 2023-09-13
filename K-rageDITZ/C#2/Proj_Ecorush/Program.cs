using Microsoft.EntityFrameworkCore;
using Proj_Ecorush.Models;
using Proj_Ecorush.Services.Interfaces;
<<<<<<< HEAD
using Proj_Ecorush.Services.Services;
=======
using Proj_Ecorush.Services.ServiceClasses;
>>>>>>> de7f96d34db6e186209990736cfd2e2f8ac08362

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<EcoRushDbContext>
(optionsAction: options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQLConnectionString")));
builder.Services.AddScoped<IWalkingCycle, WalkCycleServices>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EcoRushDbContext>(
    optionsAction: options => options.UseNpgsql(
        builder.Configuration.GetConnectionString(
            "WebApiDatabase"
        )
    )
);

builder.Services.AddScoped<IUser, UserService>();

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
