using CrudzaoFoda.Application;
using CrudzaoFoda.Application.Contratos;
using CrudzaoFoda.Persistence;
using CrudzaoFoda.Persistence.Contexto;
using CrudzaoFoda.Persistence.Contratos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FilmeDbContexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FilmeDbContexto")));

builder.Services.AddControllers();
builder.Services.AddScoped<IFilmeService, FilmeService>();
builder.Services.AddScoped<IFilmesPersist, FilmesPersist>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
