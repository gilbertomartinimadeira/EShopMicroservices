using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using static Discount.Grpc.DiscountProtoService;

namespace Discount.Grpc.Services;

public class DiscountService(DiscountContext db, ILogger<DiscountService> logger) : DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        // TODO: GetDiscount from database
        logger.LogInformation("Fetching coupon from database...");
        var coupon = await db.FindAsync<Coupon>(request.ProductName);

        if(coupon is null) {
            logger.LogInformation("Coupon was not found");
        };

        return new CouponModel() {
            Amount = coupon?.Amount ?? 0,
            Description = coupon?.ProductDescription ?? "",
            ProductName = coupon?.ProductName ?? request.ProductName
        };
    
    }

    public override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {
        return base.CreateDiscount(request, context);
    }

    public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
    {
        return base.UpdateDiscount(request, context);
    }

    public override Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
    {
        return base.DeleteDiscount(request, context);
    }
}
