using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;
using static Discount.Grpc.DiscountProtoService;

namespace Discount.Grpc.Services;

public class DiscountService
(DiscountContext db, ILogger<DiscountService> logger)
 : DiscountProtoServiceBase
{
    public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
    {
        var coupon = await db.Coupons
                             .FirstOrDefaultAsync(
                                p => p.ProductName == request.ProductName
                             );

        if (coupon is null)
        {
            coupon = new Coupon { ProductName = "No Discount", Amount = 0, Description = "No Discount Desc" };
        };

        logger.LogInformation("Discount is retrieved for ProductName: {productName}", request.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;


    }

    public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
    {

        //Get incoming request
        var coupon = request.Coupon.Adapt<Coupon>();
        if (coupon is null)
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request object."));


        db.Coupons.Add(coupon);
        await db.SaveChangesAsync();

        logger.LogInformation("Discount was successfully created. ProductName : {ProductName}", coupon.ProductName);

        var couponModel = coupon.Adapt<CouponModel>();
        return couponModel;


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
