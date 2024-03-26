
namespace Catalog.API.Products.GetProductByCategory;

public record GetProductsByCategoryRequest(string Category);

public record GetProductsByCategoryResponse(IEnumerable<Product> Products);



public class GetProductByCategoryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (ISender sender, string category) =>
        {

            var query = new GetProductsByCategoryRequest(category);

            var response = await sender.Send(query.Adapt<GetProductsByCategoryQuery>());

            return new GetProductsByCategoryResponse(response.Products);

        });
    }
}
