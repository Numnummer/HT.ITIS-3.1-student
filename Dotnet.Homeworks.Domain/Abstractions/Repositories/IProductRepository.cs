using Dotnet.Homeworks.Domain.Entities;
using Dotnet.Homeworks.Shared.Dto;

namespace Dotnet.Homeworks.Domain.Abstractions.Repositories;

public interface IProductRepository
{
    Task<Result<IEnumerable<Product>>> GetAllProductsAsync(CancellationToken cancellationToken);
    
    Task<Result<Product>> GetProductByNameAsync(string name, CancellationToken cancellationToken);
    
    Task<Result> DeleteProductByGuidAsync(Guid guid, CancellationToken cancellationToken);
    
    Task<Result> UpdateProductAsync(Product product, CancellationToken cancellationToken);
    
    Task<Result<Guid>> InsertProductAsync(Product product, CancellationToken cancellationToken);
}