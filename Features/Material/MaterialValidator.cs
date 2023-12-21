using FluentValidation;
using TestExersize.Models;

public class MaterialValidator : AbstractValidator<Material>
{
  public MaterialValidator()
  {
    //правило для айди
    RuleFor(material => material.Id).NotEmpty().WithMessage("Material Id must be not Empty");//не пустое
    //правило для имени
    RuleFor(material => material.Name).NotEmpty().WithMessage("Material Name must be not Empty");//не пустое
    //правило для цены
    RuleFor(material => material.Price).NotEmpty().WithMessage("Material Price must be not Empty")//не пустое
    .GreaterThan(0).WithMessage("Material Price must be more than 0");// больше 0
    //правило для айди продавца
    RuleFor(material => material.SellerId).NotEmpty().WithMessage("Material SellerId must be not Empty");//не пустое
  }
}