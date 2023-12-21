using TestExersize.Models;
using MediatR;

// объявление запроса на удаление материала
public record DeleteMaterialQuery(int Id) : IRequest<IEnumerable<Material>>;


// обработчик удаления материала
public class DeleteMaterialHandler : IRequestHandler<DeleteMaterialQuery, IEnumerable<Material>> 
{ 
    private readonly MaterialExampleDataStore _materialExampleDataStore; 
        
    public DeleteMaterialHandler(MaterialExampleDataStore materialExampleDataStore) => _materialExampleDataStore = materialExampleDataStore;

    public async Task<IEnumerable<Material>> Handle(DeleteMaterialQuery request, CancellationToken cancellationToken)=>
        await _materialExampleDataStore.DeleteMaterial(request.Id);

}