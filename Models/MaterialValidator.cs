using FluentValidation;
using TestExersize.Models;

public class MaterialValidator : AbstractValidator<Material>
{
  public MaterialValidator()
  {
    RuleFor(material => material.Id).NotEmpty().WithMessage("Material Id must be not Empty");//не пустое
    RuleFor(material => material.Name).NotEmpty().WithMessage("Material Name must be not Empty");//не пустое
    RuleFor(material => material.Price).NotEmpty().GreaterThan(0).WithMessage("Material Price must be more than 0 and not Empty");//не пустое, больше 0
    RuleFor(material => material.SellerId).NotEmpty().WithMessage("Material SellerId must be not Empty");//не пустое
  }
}