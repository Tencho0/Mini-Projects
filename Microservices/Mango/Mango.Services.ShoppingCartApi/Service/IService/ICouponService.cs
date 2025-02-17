namespace Mango.Services.ShoppingCartApi.Service.IService
{
    using Mango.Services.ShoppingCartApi.Models.Dto;

    public interface ICouponService
    {
        Task<CouponDto> GetCoupon(string couponCode);
    }
}
