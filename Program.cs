using apiNetcoreDemo.Data.Entity;
using apiNetcoreDemo.Helper;
using apiNetcoreDemo.Interface;
using apiNetcoreDemo.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
});

builder.Services.AddTransient<IServiceManager, ServiceDataMaster>();
builder.Services.AddTransient<IUserManager, UserDataService>();
builder.Services.AddTransient<IJwtHandler, JwtHandler>();
builder.Services.AddTransient<ICategoryManager, CategoryService>();

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
