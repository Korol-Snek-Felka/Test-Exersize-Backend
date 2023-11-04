using MediatR;
using TestExersize.Models;

// обработчик удаления материала
public class DeleteMaterialHandler : IRequestHandler<DeleteMaterialQuery, IEnumerable<Material>> 
{ 
    private readonly MaterialExampleDataStore _materialExampleDataStore; 
        
    public DeleteMaterialHandler(MaterialExampleDataStore materialExampleDataStore) => _materialExampleDataStore = materialExampleDataStore;

    public async Task<IEnumerable<Material>> Handle(DeleteMaterialQuery request, CancellationToken cancellationToken)=>
        await _materialExampleDataStore.DeleteMaterial(request.Id);

}