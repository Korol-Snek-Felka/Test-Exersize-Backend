using MediatR;
using TestExersize.Models;

// обработчик получения списка всех материалов
public class GetMaterialsHandler : IRequestHandler<GetMaterialsQuery, IEnumerable<Material>>
{
    private readonly MaterialExampleDataStore _materialExampleDataStore;

    public GetMaterialsHandler(MaterialExampleDataStore materialExampleDataStore) => _materialExampleDataStore = materialExampleDataStore;

    public async Task<IEnumerable<Material>> Handle(GetMaterialsQuery request,
        CancellationToken cancellationToken) => await _materialExampleDataStore.GetAllMaterials();
}