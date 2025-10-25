using Microsoft.EntityFrameworkCore;
using TP_ProgramaciónII_PIPORAMA.Data.Models;
using TP_ProgramaciónII_PIPORAMA.Repositories.Implementations;
using TP_ProgramaciónII_PIPORAMA.Repositories.Interfaces;
using TP_ProgramaciónII_PIPORAMA.Services.Implementations;
using TP_ProgramaciónII_PIPORAMA.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/* INYECCION DE MARTI */
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
/* INYECCION DE JERO Y PIPO */
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClientService, ClientService>();

builder.Services.AddDbContext<PIPORAMAContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
