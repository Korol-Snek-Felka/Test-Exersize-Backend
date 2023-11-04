using TestExersize.Models;
using MediatR;

///  **объявление команд на добавление

// объявление для материала.
public record AddMaterialCommand(Material Material) : IRequest<Material>;
// объявление для продавца.
public record AddSellerCommand(Seller Seller) : IRequest<Seller>;