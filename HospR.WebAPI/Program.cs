using HospR.Core.Entities;
using Microsoft.Extensions.DependencyInjection.Extensions;
using HospR.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<HospRDbContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/patient", () => new Patient(1, "Ivan", "+380", "p@gmail.com")); //test Patient record

app.MapGet("/show/patient/{id:int}/{name:alpha}",
    (int id, string name) => 
        new Patient(id, name, String.Empty, String.Empty));

app.Run();