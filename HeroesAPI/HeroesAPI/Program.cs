using HeroesAPI.Data;
using HeroesAPI.Repositories;
using HeroesAPI.Repositories.Interfaces;
using HeroesAPI.Services;
using HeroesAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuração do DbContext para usar o banco In-Memory
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

// Registro dos serviços
builder.Services.AddScoped<IHeroRepository, HeroRepository>();
builder.Services.AddScoped<IHeroisSuperpoderesRepository, HeroisSuperpoderesRepository>();
builder.Services.AddScoped<ISuperpoderRepository, SuperpoderRepository>();

builder.Services.AddScoped<IHeroesService, HeroesService>();
builder.Services.AddScoped<ISuperpoderService, SuperpoderService>();

// Adicionar os controladores
builder.Services.AddControllers();

// Adicionar o Swagger (para desenvolvimento)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngular");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
