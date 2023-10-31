using FluentValidation;
using TestExersize.Models;

public class SellerValidator : AbstractValidator<Seller>
{
  public SellerValidator()
  {
    RuleFor(seller => seller.Id).NotEmpty().WithMessage("Seller Id must be not Empty");//не пустое
    RuleFor(seller => seller.Name).NotEmpty().WithMessage("Seller Name must be not Empty");//не пустое
  }
}