using MediatR;

namespace Dotnet.Homeworks.Features.Products.Commands.DeleteProduct;

internal sealed class DeleteProductByGuidCommandHandler : IRequestHandler<DeleteProductByGuidCommand>
{
    public Task Handle(DeleteProductByGuidCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}