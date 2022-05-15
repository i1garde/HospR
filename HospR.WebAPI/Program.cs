using HospR.Core.Entities;
using HospR.Infrastructure;
using Microsoft.EntityFrameworkCore;
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

// TODO: Join Patient and PatientCard Entities as they have 1 to 1 relationship and 
// anyway in db they 'll join in one
app.MapGet("/patient", () => new Patient("Ivan", "+380", "p@gmail.com")); //test Patient record

List<Patient> patList = new List<Patient>();
patList.Add(new Patient("Ivan", "+380", "p@gmail.com"));
patList.Add(new Patient("Daria", "+3801", "d@gmail.com"));
patList.Add(new Patient("Maria", "+3802", "m@gmail.com"));

app.MapGet("/patients", () => patList);

app.MapGet("/show/patient/{id:int}/{name:alpha}",
    (int id, string name) => 
        new Patient(name, String.Empty, String.Empty));

app.Run();