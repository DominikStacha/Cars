using System.Text.Json.Serialization;
using Cars.Domain.Entities;
using Cars.Domain.Models;
using Cars.Migrations;
using Cars.Repository;
using Cars.Repository.Base;
using Cars.Repository.IncludeHelpers;
using Cars.Repository.Interfaces;
using Cars.Service.Base;
using Cars.Service.Interfaces;
using Cars.Service.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("connection"))
);
AutoMapperConfiguration.Init();

#region DI setup

builder.Services.AddScoped<IIncludeHelper<Car>, CarIncludeHelper>();
builder.Services.AddScoped<IIncludeHelper<User>, UserIncludeHelper>();

builder.Services.AddScoped<IRepository<Car>, RepositoryBase<Car>>();
builder.Services.AddScoped<IRepository<User>, RepositoryBase<User>>();

builder.Services.AddScoped<IService<Car, CarModel>, EntityServiceBase<Car, CarModel>>();
builder.Services.AddScoped<IService<User, UserModel>, EntityServiceBase<User, UserModel>>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.ApplyMigrations();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();