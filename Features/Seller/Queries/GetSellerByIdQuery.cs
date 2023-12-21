using TestExersize.Models;
using MediatR;

// объявление запроса на получение продавца по его айди
public record GetSellerByIdQuery(int Id) : IRequest<Seller>;


// обработчик получения продавца по его айди
public class GetSellerByIdHandler : IRequestHandler<GetSellerByIdQuery, Seller>
{
    private readonly SellerExampleDataStore _sellerExampleDataStore;

    public GetSellerByIdHandler(SellerExampleDataStore sellerExampleDataStore) => _sellerExampleDataStore = sellerExampleDataStore;

    public async Task<Seller> Handle(GetSellerByIdQuery request, CancellationToken cancellationToken) =>
        await _sellerExampleDataStore.GetSellerById(request.Id);
        
}