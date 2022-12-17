using CadastroReceitas.Application.Interfaces;
using CadastroReceitas.Application.Services;
using CadastroReceitas.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connection = @"Server=(localdb)\mssqllocaldb;Database=CadastroReceitas;Trusted_Connection=True;ConnectRetryCount=0";
builder.Services.AddDbContext<ApplicationDbContext>
    (o => o.UseSqlServer(connection));

builder.Services.AddControllers();

builder.Services.AddTransient<IReceitaService, ReceitaService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    s => {
        s.SwaggerDoc("v1", new OpenApiInfo() { Title = "Api CadastroReceitas", Version = "V1" });
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
