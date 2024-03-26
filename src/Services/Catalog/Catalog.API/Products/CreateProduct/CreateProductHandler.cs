namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(
                                    string Name,
                                    List<string> Category,
                                    string Description,
                                    string ImageFile,
                                    decimal Price) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);

public class CreateProductHandler(IDocumentSession session)
: ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //perform business logic to create a product

        // Create a product Entity
        var product = new Product()
        {
            Name = command.Name,
            Description = command.Description,
            Category = command.Category,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        // TODO: save to database
        session.Store(product);

        try
        {
            await session.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        //  return CreateProductResult result
        return await Task.FromResult(new CreateProductResult(product.Id));

    }
}