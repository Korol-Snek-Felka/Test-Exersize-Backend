using TestExersize.Models;
public class SellerExampleDataStore
{
    private static List<Seller> _sellers;
    public SellerExampleDataStore()
    {
        _sellers = new List<Seller>
        {
            new Seller { Id = 1, Name = "Северсталь"},
            new Seller { Id = 2, Name = "Волгоградский алюминиевый завод"},
            new Seller { Id = 3, Name = "Удоканская медь"},
            new Seller { Id = 4, Name = "Норникель"}
        };
    }
    //добавить продавца
    public async Task AddSeller(Seller seller)
    { 
        _sellers.Add(seller);
        await Task.CompletedTask;
    }
    //найти продавца по его айди
    public async Task<Seller> GetSellerById(int id) => 
        await Task.FromResult(_sellers.Single(p => p.Id == id));
        
    //получить список всех продавцов
    public async Task<IEnumerable<Seller>> GetAllSellers() => await Task.FromResult(_sellers);

    //удалить продавца
    public async Task<IEnumerable<Seller>> DeleteSeller(int id) {
        //проверяем, существует ли такой продавец
        try {
            Seller seller = await GetSellerById(id);
            _sellers.Remove(seller);
        } catch(InvalidOperationException) {
           throw new InvalidOperationException("This seller is not exist!");//проверка на существование продавца
        }
        return await Task.FromResult(_sellers);// возвращение списка всех продавцов кроме удаленного
    }
    //обновить продавца
    public async Task UpdateSeller(int id,Seller seller)
    {   
        
        try{// Проверка на существование продавца
            Seller existingSeller = await GetSellerById(id);
            //здесь можно задать обновление данных
            existingSeller.Id = seller.Id;//обновление айди продавца
            existingSeller.Name = seller.Name;//обновление имени продавца
        }
        catch{
            throw new InvalidOperationException("This seller is not exist!"); 
        }
        await Task.CompletedTask;
    }
}