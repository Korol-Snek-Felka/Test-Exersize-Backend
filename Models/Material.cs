namespace TestExersize.Models;
public class Material{
    private int Id;
    private string? Name;
    private decimal Price;
    private int SellerId;
    public Material(){}
    public Material(int id, string name, decimal price, int sellerId){
        Id=id;
        Name=name;
        Price=price;
        SellerId=sellerId;
    }
}