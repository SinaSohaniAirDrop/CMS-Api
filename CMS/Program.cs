global using CMS.Models;
global using CMS.Data;
global using Microsoft.EntityFrameworkCore;
global using CMS.Data;
global using System.ComponentModel;
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
using CMS.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default")
    ?? throw new NullReferenceException("تنظیمات دیتابیس در config یافت نشد!");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddScoped<IComCostService, ComCostService>(); 
builder.Services.AddScoped<IInsuranceService, InsuranceService>(); 
builder.Services.AddScoped<IPackagingService, PackagingService>(); 
builder.Services.AddScoped<IVolDistService, VolDistService>(); 
builder.Services.AddScoped<IProvinceService, ProvinceService>(); 
builder.Services.AddDbContextFactory<DataContext>((
    DbContextOptionsBuilder options) =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();
    dbContext.Database.Migrate();
}

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
