using TestExersize.Models;
using MediatR;

// объявление команды на обновление продавца.
public record UpdateSellerCommand(int Id, Seller Seller) : IRequest<Seller>;


// обработчик обновления продавца
public class UpdateSellerHandler : IRequestHandler<UpdateSellerCommand, Seller> 
{ 
    private readonly SellerExampleDataStore _sellerExampleDataStore; 
        
    public UpdateSellerHandler(SellerExampleDataStore sellerExampleDataStore) => _sellerExampleDataStore = sellerExampleDataStore; 
        
    public async Task<Seller> Handle(UpdateSellerCommand  request, CancellationToken cancellationToken) 
    {
        await _sellerExampleDataStore.UpdateSeller(request.Id, request.Seller); 
            
        return request.Seller; 
    }
}