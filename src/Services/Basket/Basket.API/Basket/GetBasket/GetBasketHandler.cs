namespace Basket.API.Basket.GetBasket;

public record GetBasketQuery(in string UserName) : IQuery<GetBasketResult>;

public record GetBasketResult(ShoppingCart Cart);


public class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketResult>
{
    public async Task<GetBasketResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        //TODO: Get Basket from database

        // return basket as Result
        return new GetBasketResult(new ShoppingCart("gil") { });
    }
}
