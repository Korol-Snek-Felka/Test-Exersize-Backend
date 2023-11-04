using TestExersize.Models;
public class MaterialExampleDataStore
{
    private static List<Material> _materials;
    public MaterialExampleDataStore()
    {
        _materials = new List<Material>
        {
            new Material { Id = 1, Name = "Сталь", Price = 10, SellerId = 1},
            new Material { Id = 2, Name = "Алюминий", Price = 23, SellerId = 2},
            new Material { Id = 3, Name = "Медь", Price = 41, SellerId = 3},
            new Material { Id = 4, Name = "Никель", Price = 60, SellerId = 4},
            new Material { Id = 5, Name = "Кобальт", Price = 102, SellerId = 4}
        };
    }

    //добавить материал
    public async Task AddMaterial(Material material)
    {   
        SellerExampleDataStore sellerExampleDataStore = new SellerExampleDataStore();
        try {
            Seller result = await sellerExampleDataStore.GetSellerById(material.SellerId);
        } catch(InvalidOperationException) {
           throw new InvalidOperationException("This seller is not exist!");//проверка на существование продавца
        }

        _materials.Add(material);
        await Task.CompletedTask;
    }

    //найти материал по его айди
    public async Task<Material> GetMaterialById(int id) => 
        await Task.FromResult(_materials.Single(p => p.Id == id));
        
    //получить список всех материалов
    public async Task<IEnumerable<Material>> GetAllMaterials() => await Task.FromResult(_materials);

    //удалить материал
    public async Task<IEnumerable<Material>> DeleteMaterial(int id) {
        //проверяем, существует ли такой материал
        try {
            Material material = await GetMaterialById(id);
            _materials.Remove(material);
        } catch(InvalidOperationException) {
           throw new InvalidOperationException("This material is not exist!");//проверка на существование продавца
        }
        return await Task.FromResult(_materials);// возвращение списка всех материалов кроме удаленного
    }

    //обновить материал
    public async Task UpdateMaterial(int id,Material material)
    {   
        try// Проверка на существование материала
        {
            Material existingMaterial = await GetMaterialById(id);//поиск существующего  материала
            //здесь можно задать обновление данных
            existingMaterial.Id = material.Id;//обновление айди материала
            existingMaterial.Name = material.Name;//обновление имени материала
            existingMaterial.Price = material.Price;//обновление цены материала

            try{// Проверка на существование продавца
                var sellerDataStore = new SellerExampleDataStore();
                var seller = await sellerDataStore.GetSellerById(material.SellerId);

                existingMaterial.SellerId = material.SellerId;//обновление айди продавца
            } catch{
                throw new InvalidOperationException("This seller is not exist!"); //ошибка такого продавца нет
            }
        }
        catch{
            throw new InvalidOperationException("This material is not exist!"); //ошибка такого материала нет
        }
        await Task.CompletedTask;
    }
        
}