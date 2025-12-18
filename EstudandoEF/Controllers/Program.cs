using Microsoft.EntityFrameworkCore;
using TarefaApi.Data;
using TarefaApi.Repository;
using TarefaApi.Service;

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
