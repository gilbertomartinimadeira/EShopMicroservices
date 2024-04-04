
namespace Basket.API.Basket.GetBasket;

//public record GetBasketRequest(string UserName);

public record GetBasketResponse(ShoppingCart Cart);
public class GetBasketEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/basket/{username}", async (string username, ISender sender) =>
        {

            var result = await sender.Send(new GetBasketQuery(username));

            var response = result.Adapt<GetBasketResponse>();
        }).WithName("GetBasket")
          .Produces<GetBasketResponse>(StatusCodes.Status200OK)
          .ProducesProblem(StatusCodes.Status200OK)
          .WithSummary("Get basket for user")
          .WithDescription("Get basket for user");
    }
}
