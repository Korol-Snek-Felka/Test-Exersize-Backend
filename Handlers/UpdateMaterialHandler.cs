using MediatR;
using TestExersize.Models;

// обработчик обновления материала
public class UpdateMaterialHandler : IRequestHandler<UpdateMaterialCommand, Material> 
{ 
    private readonly MaterialExampleDataStore _materialExampleDataStore; 
        
    public UpdateMaterialHandler(MaterialExampleDataStore materialExampleDataStore) => _materialExampleDataStore = materialExampleDataStore; 
        
    public async Task<Material> Handle(UpdateMaterialCommand  request, CancellationToken cancellationToken) 
    {
        await _materialExampleDataStore.UpdateMaterial(request.Id, request.Material); 
            
        return request.Material; 
    }
}