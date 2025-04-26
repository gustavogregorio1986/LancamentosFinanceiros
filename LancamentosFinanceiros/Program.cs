using AutoMapper;
using LancamentosFinanceiros.Data.Context;
using LancamentosFinanceiros.Data.Mapping;
using LancamentosFinanceiros.Data.Repository;
using LancamentosFinanceiros.Data.Repository.Interface;
using LancamentosFinanceiros.Service.Service;
using LancamentosFinanceiros.Service.Service.Interface;
using Microsoft.EntityFrameworkCore;
using LancamentosFinanceiros.Data.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(FinanceiroMapping));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbContexto>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFinanceiroRepository, FinanceiroRepository>();
builder.Services.AddScoped<IFinanceiroService, FinanceiroService>();

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
