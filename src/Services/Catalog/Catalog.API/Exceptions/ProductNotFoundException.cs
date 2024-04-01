using System.Runtime.Serialization;
using BuildingBlocks.Exceptions;

namespace Catalog.API.Exceptions;


[Serializable]
internal class ProductNotFoundException(Guid Id) : NotFoundException("Product", Id)
{
}