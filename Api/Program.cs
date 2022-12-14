
using Api;
using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using DataAccess.Concrete.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Services.DependencyResolvers;
using Services.Extensions;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.


builder.Services.AddDbContext<BoynerCaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging();
});


builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureMapping();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.DISet();

IConfiguration configuration = builder.Configuration;
var multiplexer = ConnectionMultiplexer.Connect(configuration.GetConnectionString("Redis"));
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();
app.UseSwaggerUI();
app.CreateDb();
app.UseAuthorization();

app.MapControllers();

app.Run();
