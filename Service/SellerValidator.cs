using FluentValidation;
using TestExersize.Models;

public class SellerValidator : AbstractValidator<Seller>
{
  public SellerValidator()
  {
    //правило для айди
    RuleFor(seller => seller.Id).NotEmpty().WithMessage("Seller Id must be not Empty");//не пустое
    //правило для имени
    RuleFor(seller => seller.Name).NotEmpty().WithMessage("Seller Name must be not Empty");//не пустое
  }
}