using Hangfire;

public class PriceUpdater
{
    private readonly IServiceProvider _serviceProvider;

    public PriceUpdater(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [AutomaticRetry(Attempts = 0)] // Перезапуск задачи в случае ошибки
    public void UpdatePrices()
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var materialDataStore = scope.ServiceProvider.GetRequiredService<MaterialExampleDataStore>();
            var materials = materialDataStore.GetAllMaterials().Result;

            Random random = new Random();

            foreach (var material in materials)
            {
                int priceChange = random.Next(1, 101); // Цена увеличивается на 1 - 100 единиц
                material.Price += priceChange;
            }
        }
    }
}
