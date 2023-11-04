using TestExersize.Models;
using MediatR;

/// **объявление запросов на получение списка всех субъектов


// объявление для метариала.
public record GetMaterialsQuery() : IRequest<IEnumerable<Material>>;
// объявление для продавца.
public record GetSellersQuery() : IRequest<IEnumerable<Seller>>;