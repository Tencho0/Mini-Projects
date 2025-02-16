namespace Mango.Services.ShoppingCartApi
{
    using AutoMapper;
    using Mango.Services.ShoppingCartApi.Models;
    using Mango.Services.ShoppingCartApi.Models.Dto;

    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CartHeader, CartHeaderDto>().ReverseMap();
                config.CreateMap<CartDetails, CartDetailsDto>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
