namespace Mango.Services.OrderApi
{
    using AutoMapper;
    using Mango.Services.OrderApi.Models;
    using Mango.Services.OrderApi.Models.Dto;

    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderHeaderDto, CartHeaderDto>()
                .ForMember(dest => dest.CartTotal, u => u.MapFrom(src => src.OrderTotal))
                .ReverseMap();

                config.CreateMap<CartDetailsDto, OrderDetailsDto>()
                    .ForMember(dest => dest.ProductName, u => u.MapFrom(src => src.Product.Name))
                    .ForMember(dest => dest.Price, u => u.MapFrom(src => src.Product.Price));

                config.CreateMap<OrderDetailsDto, CartDetailsDto>();

                config.CreateMap<OrderHeader, OrderHeaderDto>().ReverseMap();
                config.CreateMap<OrderDetailsDto, OrderDetails>().ReverseMap();
            });

            return mappingConfig;
        }
    }
}
