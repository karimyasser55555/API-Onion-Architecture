using Application.Contracts;
using Application.Features.Categories.Queries.FilterCategories;
using Context;
using FluentValidation;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using QenaDtos.Category;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<QenaDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("QenaConnectionStrings")));
builder.Services.AddMediatR(config =>
config.RegisterServicesFromAssembly(typeof(FilterCategoriesQuery).Assembly
));
builder.Services.AddValidatorsFromAssembly(typeof(FilterCategoriesQuery).Assembly);
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
