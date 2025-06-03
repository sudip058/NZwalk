using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NZwalk.API.Data;
using NZwalk.API.Mapping;
using NZwalk.API.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<NZWalksDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection")));

// for the repository IRegionRepostory

builder.Services.AddScoped<IRegionRepository , SQLRegionRepository>();

//for the repository IWalkRepository

builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();

//for the auto mapper 

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


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
