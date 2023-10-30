using Hangfire;
using TestExersize.Models;
public class PriceUpdater
{
    private readonly IServiceProvider _serviceProvider;

    public PriceUpdater(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    //метод для обновления цены
    [AutomaticRetry(Attempts = 0)] // Перезапуск задачи в случае ошибки
    public void UpdatePrices()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<TestExersizeContext>();
            var materials = dbContext.MaterialItems.ToList();

            Random random = new Random();

            foreach (var material in materials)
            {
                int priceChange = random.Next(1, 101);//цена увеличивается на от 1 до 100
                material.Price += priceChange;
            }

            dbContext.SaveChanges();
        }
    }
}

