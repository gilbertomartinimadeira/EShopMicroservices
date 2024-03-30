namespace Catalog.API.Products.CreateProduct;

public record CreateProductCommand(
                                    string Name,
                                    List<string> Category,
                                    string Description,
                                    string ImageFile,
                                    decimal Price) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(c => c.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(c => c.ImageFile).NotEmpty().WithMessage("ImageFile is required");
        RuleFor(c => c.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
    }
}

public class CreateProductHandler
(IDocumentSession session, IValidator<CreateProductCommand> validator)
: ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        // validate command prior to create a product
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

        if(errors.Any()){
            // I'm just following the tutorial, I wouldn't do this..
            throw new ValidationException(errors.FirstOrDefault());
        }

        // Create a product Entity
        var product = new Product()
        {
            Name = command.Name,
            Description = command.Description,
            Category = command.Category,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        // Save to database
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