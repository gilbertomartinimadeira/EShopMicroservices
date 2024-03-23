using BuildingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;

public record CreateProductCommand(
                                    string Name, 
                                    List<string> Category, 
                                    string Description, 
                                    string ImageFile, 
                                    decimal Price) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);

public class CreateProductHandler 
: ICommandHandler<CreateProductCommand, CreateProductResult>{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //perform business logic to create a product
        
        // Create a product Entity
        var product = new Product(){
            Name = command.Name,
            Description = command.Description,
            Category = command.Category,
            ImageFile = command.ImageFile,
            Price = command.Price    
        };
        
        // TODO: save to database
        

        //  return CreateProductResult result

        return new CreateProductResult(Guid.NewGuid());
            
    }
}