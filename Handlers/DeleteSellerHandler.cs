using MediatR;
using TestExersize.Models;

// обработчик удаления материала
public class DeleteSellerHandler : IRequestHandler<DeleteSellerQuery, IEnumerable<Seller>> 
{ 
    private readonly SellerExampleDataStore _sellerExampleDataStore; 
        
    public DeleteSellerHandler(SellerExampleDataStore sellerExampleDataStore) => _sellerExampleDataStore = sellerExampleDataStore;

    public async Task<IEnumerable<Seller>> Handle(DeleteSellerQuery request, CancellationToken cancellationToken)=>
        await _sellerExampleDataStore.DeleteSeller(request.Id);

}