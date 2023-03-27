using Microsoft.EntityFrameworkCore;
using TodoCQRS.API.Controllers;
using TodoCQRS.Application.Mapping;
using TodoCQRS.Infrastructure.Data.Context;
using TodoCQRS.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
MappingConfig.Configure();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("TodoCQRS.Infrastructure")));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(TodosController).Assembly));
builder.Services.AddScoped<ITodoRepository, TodoRepository>();

builder.Services.Configure<RouteOptions>(options => { options.LowercaseUrls = true; });

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();