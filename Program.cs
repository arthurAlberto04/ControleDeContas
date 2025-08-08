using ControleDeConta.Data;
using ControleDeConta.Modelos;
using ControleDeConta.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<ControleDeContasContext> //banco de dados
    (opts => opts.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<DividaService>();
builder.Services.AddScoped<DevedorService>();
builder.Services.AddScoped<PagamentoService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ControleDeContasContext>();
    var dividas = db.Dividas.ToList();
    foreach (var divida in dividas)
    {
            var novoValor = divida.CalcularJuros();
            divida.valor = divida.valor + novoValor;   
    }
    db.SaveChanges();
}

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
