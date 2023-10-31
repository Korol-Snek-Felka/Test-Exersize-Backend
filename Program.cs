using Microsoft.EntityFrameworkCore;
using TestExersize.Models;
using Hangfire;
using Hangfire.MemoryStorage;
using FluentValidation;
using FluentValidation.AspNetCore;
//using FluentValidationInAspCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<TestExersizeContext>(opt =>
    opt.UseInMemoryDatabase("List"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure Hangfire with in-memory storage
builder.Services.AddHangfire(configuration => configuration.UseMemoryStorage());
builder.Services.AddHangfireServer();

// Add validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<SellerValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<MaterialValidator>();

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

// Configure Hangfire dashboard
app.UseHangfireDashboard();

var serviceProvider = app.Services;
var priceUpdater = new PriceUpdater(serviceProvider);

// для проверки работы цены меняются каждую минуту.
RecurringJob.AddOrUpdate("minutly-price-update", () => priceUpdater.UpdatePrices(), Cron.Minutely());

//для изменения цены по заданию, а именно раз в день в 8 утра
//RecurringJob.AddOrUpdate("daily-price-update", () => priceUpdater.UpdatePrices(), Cron.Daily(8, 0));
app.Run();