namespace Mango.Services.OrderApi.Service.IService
{
    using Mango.Services.OrderApi.Models.Dto;

    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
