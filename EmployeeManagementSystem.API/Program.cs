using EmployeeManagementSystem.DataAccess.Implemetations;
using EmployeeManagementSystem.DataAccess.Interfaces;
using EmployeeManagementSystem.Services.Implementations;
using EmployeeManagementSystem.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDbContext, DbContext>();
builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();
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
