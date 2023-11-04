using Hangfire;
using Hangfire.MemoryStorage;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Configure Hangfire with in-memory storage
builder.Services.AddHangfire(configuration => configuration.UseMemoryStorage());
builder.Services.AddHangfireServer();

// Add validation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<SellerValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<MaterialValidator>();

// Add examples of datastores and price updater
builder.Services.AddSingleton<MaterialExampleDataStore>();
builder.Services.AddSingleton<SellerExampleDataStore>();
builder.Services.AddSingleton<PriceUpdater>();

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
var priceUpdater = serviceProvider.GetRequiredService<PriceUpdater>();

// для проверки работы цены меняются каждую минуту.
RecurringJob.AddOrUpdate("minutly-price-update", () => priceUpdater.UpdatePrices(), Cron.Minutely());

//для изменения цены по заданию, а именно раз в день в 8 утра
//RecurringJob.AddOrUpdate("daily-price-update", () => priceUpdater.UpdatePrices(), Cron.Daily(8, 0));
app.Run();