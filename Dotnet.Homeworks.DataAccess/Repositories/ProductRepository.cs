using Dotnet.Homeworks.Data.DatabaseContext;
using Dotnet.Homeworks.Domain.Abstractions.Repositories;
using Dotnet.Homeworks.Domain.Entities;
using Dotnet.Homeworks.Shared.Dto;
using Microsoft.EntityFrameworkCore;

namespace Dotnet.Homeworks.DataAccess.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<IEnumerable<Product>>> GetAllProductsAsync(CancellationToken cancellationToken)
    {
        return new Result<IEnumerable<Product>>
            (await _context.Products.ToArrayAsync(cancellationToken), true);
    }

    public async Task<Result<Product>> GetProductByNameAsync(string name, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == name, cancellationToken);
        var result = new Result<Product>(product, product != null);
        return result;
    }

    public async Task<Result> DeleteProductByGuidAsync(Guid id, CancellationToken cancellationToken)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        var result = new Result(product != null);
        _context.Products.Remove(product);
        return result;
    }

    public Task<Result> UpdateProductAsync(Product product, CancellationToken cancellationToken)
    {
        _context.Products.Update(product);
        return Task.FromResult(new Result(true));
    }

    public async Task<Result<Guid>> InsertProductAsync(Product product, CancellationToken cancellationToken)
    {
        await _context.Products.AddAsync(product, cancellationToken);
        return new Result<Guid>(product.Id,true);
    }
}