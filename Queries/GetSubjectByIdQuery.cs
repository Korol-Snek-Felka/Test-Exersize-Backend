using TestExersize.Models;
using MediatR;

/// **объявление запросов на получение субъекта по его айди


// объявление материала.
public record GetMaterialByIdQuery(int Id) : IRequest<Material>;
// объявление продавца.
public record GetSellerByIdQuery(int Id) : IRequest<Seller>;