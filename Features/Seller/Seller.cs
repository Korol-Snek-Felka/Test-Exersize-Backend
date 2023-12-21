using System.ComponentModel.DataAnnotations;

namespace TestExersize.Models;
public class Seller{
    [Key]
    public int Id { get; set; }
    public string? Name{ get; set; }
}