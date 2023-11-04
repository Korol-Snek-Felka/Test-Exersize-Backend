using TestExersize.Models;
using MediatR;

/// **объявление команд на обновление субъекта


// объявление для метариала.
public record UpdateMaterialCommand(int Id, Material Material) : IRequest<Material>;
// объявление для продавца.
public record UpdateSellerCommand(int Id, Seller Seller) : IRequest<Seller>;