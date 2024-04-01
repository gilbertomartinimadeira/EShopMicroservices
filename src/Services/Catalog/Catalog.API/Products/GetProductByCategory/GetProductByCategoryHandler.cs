using Catalog.API.Exceptions;

namespace Catalog.API.Products.GetProductByCategory;

public record GetProductsByCategoryQuery(string Category) : IQuery<GetProductByCategoryResult>;

public record GetProductByCategoryResult(IEnumerable<Product> Products);


public class GetProductByCategoryHandler(IDocumentSession session)
: IQueryHandler<GetProductsByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductsByCategoryQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().Where(p => p.Category.Contains(query.Category)).ToListAsync(cancellationToken);

        if (products is null)
        {
            throw new ProductNotFoundException(Guid.NewGuid());
        }

        return new GetProductByCategoryResult(products);

    }

}
