using TestExersize.Models;
using MediatR; 

// объявление запроса на получение материала по его айди.
public record GetMaterialByIdQuery(int Id) : IRequest<Material>;


// обработчик получения материала по его айди
public class GetMaterialByIdHandler : IRequestHandler<GetMaterialByIdQuery, Material>
{
    private readonly MaterialExampleDataStore _materialExampleDataStore;

    public GetMaterialByIdHandler(MaterialExampleDataStore materialExampleDataStore) => _materialExampleDataStore = materialExampleDataStore;

    public async Task<Material> Handle(GetMaterialByIdQuery request, CancellationToken cancellationToken) =>
        await _materialExampleDataStore.GetMaterialById(request.Id);
        
}