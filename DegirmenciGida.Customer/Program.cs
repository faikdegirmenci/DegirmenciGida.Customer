using DegirmenciGida.Customer.Application;
using DegirmenciGida.Customer.Domain;
using DegirmenciGida.Customer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<CustomerDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDB")));

builder.Services.AddScoped<IAsyncRepository<Customers, Guid>, EfRepositoryBase<Customers, Guid,CustomerDbContext>>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddControllers();


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
