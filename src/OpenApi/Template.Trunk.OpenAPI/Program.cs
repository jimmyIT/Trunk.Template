using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Template.Trunk.Data.DbContexts;
using Template.Trunk.OpenAPI.Controllers;
using Template.Trunk.OpenAPI.Extension;

[assembly: ApiConventionType(typeof(ApiConvention))]

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
                .AddJsonOptions(x =>
                    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerConfig(builder.Configuration);
builder.Services.ResolveSingletonServices();
builder.Services.ResolveScopedServices();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseLazyLoadingProxies()
           .UseSqlServer(builder.Configuration[$"ConnectionStrings:DefaultConnection"]);
});

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

bool isDevelopment = app.Environment.IsDevelopment();
app.UseCustomSwagger(isDevelopment);

app.UseHttpsRedirection();

app.MapControllers();

app.Services.MigrateDatabase();

app.Run();
