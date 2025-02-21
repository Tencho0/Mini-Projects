namespace Mango.Web.Service.IService
{
    using Mango.Web.Models;

    public interface IOrderService
    {
        Task<ResponseDto?> CreateOrder(CartDto cartDto);

        Task<ResponseDto?> CreateStripeSession(StripeRequestDto stripeRequestDto);
    }
}
