using TestExersize.Models;
using MediatR;

/// **объявление запросов на удаление

//объявление для материала
public record DeleteMaterialQuery(int Id) : IRequest<IEnumerable<Material>>;
//объявление для продавца
public record DeleteSellerQuery(int Id) : IRequest<IEnumerable<Seller>>;