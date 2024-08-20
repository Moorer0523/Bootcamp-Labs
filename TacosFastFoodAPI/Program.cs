using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TacosFastFoodAPI.Data;
using TacosFastFoodAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TacoDBContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("LocalDB")));

//add automapper, looks at the assembly of where this program is being ran, to look at the mappings
//builder.Services.AddAutoMapper(typeof(DrinkProfile), typeof(TacoProfile));

builder.Services.AddAutoMapper(typeof(Program));

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
