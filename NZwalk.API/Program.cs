using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NZwalk.API.Data;
using NZwalk.API.Mapping;
using NZwalk.API.Repository;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//for the dB context

builder.Services.AddDbContext<NZWalksDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefultConnection")));
//for the authentication db context

builder.Services.AddDbContext<NZWalksAuthDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("AuthConnection")));

// for the repository IRegionRepostory

builder.Services.AddScoped<IRegionRepository , SQLRegionRepository>();

//for the repository IWalkRepository

builder.Services.AddScoped<IWalkRepository, SQLWalkRepository>();

//for the auto mapper 

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

//for settingup identity 

builder.Services.AddIdentityCore<IdentityUser>().AddRoles<IdentityRole>().
    AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("NZwalk").
    AddEntityFrameworkStores<NZWalksAuthDbContext>().
    AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
});
    

//for the authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
