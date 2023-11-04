using MediatR;
using TestExersize.Models;

// обработчик получения списка всех продавцов
public class GetSellersHandler : IRequestHandler<GetSellersQuery, IEnumerable<Seller>>
{
    private readonly SellerExampleDataStore _sellerExampleDataStore;

    public GetSellersHandler(SellerExampleDataStore sellerExampleDataStore) => _sellerExampleDataStore = sellerExampleDataStore;

    public async Task<IEnumerable<Seller>> Handle(GetSellersQuery request,
        CancellationToken cancellationToken) => await _sellerExampleDataStore.GetAllSellers();
}