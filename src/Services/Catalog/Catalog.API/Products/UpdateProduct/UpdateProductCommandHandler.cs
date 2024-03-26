
using Catalog.API.Exceptions;

namespace Catalog.API.Products.UpdateProduct;

public record UpdateProductCommand(Guid Id,
                                 string Name,
                           List<string> Category,
                                 string Description,
                                 string ImageFile,
                                decimal Price) : ICommand<UpdateProductResult>;


public record UpdateProductResult(bool IsSuccess);

public class UpdateProductCommandHandler(IDocumentSession session,
                     ILogger<UpdateProductCommandHandler> logger)
: ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand command,
    CancellationToken cancellationToken)
    {
        logger.LogInformation("UpdateProductCommandHandler.Handle called with {@Command}", command);

        var productDb = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (productDb is null)
        {
            throw new ProductNotFoundException();
        }

        productDb = command.Adapt<Product>();

        session.Update(productDb);

        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}
