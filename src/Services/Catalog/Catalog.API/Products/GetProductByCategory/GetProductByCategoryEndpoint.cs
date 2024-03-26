
namespace Catalog.API.Products.GetProductByCategory;

public record GetProductsByCategoryRequest(string Category);

public record GetProductsByCategoryResponse(IEnumerable<Product> Products);



public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (ISender sender, string category) =>
        {

            var result = await sender.Send(new GetProductsByCategoryQuery(category));
            var response = result.Adapt<GetProductsByCategoryResponse>();
            return Results.Ok(response);

        });
    }
}
