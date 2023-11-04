using MediatR;
using TestExersize.Models;

// обработчик добавления материала
public class AddMaterialHandler : IRequestHandler<AddMaterialCommand, Material> 
{ 
    private readonly MaterialExampleDataStore _materialExampleDataStore; 
        
    public AddMaterialHandler(MaterialExampleDataStore materialExampleDataStore) => _materialExampleDataStore = materialExampleDataStore; 
        
    public async Task<Material> Handle(AddMaterialCommand  request, CancellationToken cancellationToken) 
    {
        await _materialExampleDataStore.AddMaterial(request.Material); 
            
        return request.Material; 
    }
}