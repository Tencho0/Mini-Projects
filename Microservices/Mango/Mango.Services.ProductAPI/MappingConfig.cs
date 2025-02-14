namespace Mango.Services.PorudctApi
{
    using AutoMapper;
    using Mango.Services.ProductApi.Models;
    using Mango.Services.ProductApi.Models.Dto;

    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductDto, Product>();
                config.CreateMap<Product, ProductDto>();
            });

            return mappingConfig;
        }
    }
}
