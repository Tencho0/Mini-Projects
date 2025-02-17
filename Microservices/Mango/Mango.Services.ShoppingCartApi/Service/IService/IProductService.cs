namespace Mango.Services.ShoppingCartApi.Service.IService
{
    using Mango.Services.ShoppingCartApi.Models.Dto;

    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
