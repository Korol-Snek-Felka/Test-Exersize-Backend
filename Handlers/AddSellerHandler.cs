using MediatR;
using TestExersize.Models;

// обработчик добавления продавца
public class AddSellerHandler : IRequestHandler<AddSellerCommand, Seller> 
{ 
    private readonly SellerExampleDataStore _sellerExampleDataStore; 
        
    public AddSellerHandler(SellerExampleDataStore sellerExampleDataStore) => _sellerExampleDataStore = sellerExampleDataStore; 
        
    public async Task<Seller> Handle(AddSellerCommand request, CancellationToken cancellationToken) 
    {
        await _sellerExampleDataStore.AddSeller(request.Seller); 
            
        return request.Seller; 
    }
}