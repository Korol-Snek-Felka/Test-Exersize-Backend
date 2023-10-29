using System.ComponentModel.DataAnnotations;

namespace TestExersize.Models;
public class Material{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public int SellerId { get; set; }
}