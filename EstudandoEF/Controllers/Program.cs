using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TarefaApi.Data;
using TarefaApi.Repository;
using TarefaApi.Service.CategoryService;
using TarefaApi.Service.TarefaService;
using TarefaApi.Service.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

string? StringDeConexao = builder.Configuration.GetConnectionString("StringConexaoPostGres");

if (StringDeConexao is null)
{
    throw new Exception("string de conexão não definida");
}
builder.Services.AddDbContext<TarefaApiContext>(opt => opt.UseNpgsql(StringDeConexao));

builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<TarefaRepository>();
builder.Services.AddScoped<TarefaService>();
builder.Services.AddAutoMapper(typeof(CategoryProfile));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
