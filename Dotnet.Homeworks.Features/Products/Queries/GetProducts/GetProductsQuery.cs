using Dotnet.Homeworks.Shared.Dto;
using MediatR;

namespace Dotnet.Homeworks.Features.Products.Queries.GetProducts;

public class GetProductsQuery : IRequest<Result<GetProductsDto>>
{
    
}