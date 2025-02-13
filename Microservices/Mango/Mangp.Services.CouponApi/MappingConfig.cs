namespace Mango.Services.CouponApi
{
    using AutoMapper;
    using Mango.Services.CouponApi.Models;
    using Mango.Services.CouponApi.Models.Dto;

    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponDto, Coupon>();
                config.CreateMap<Coupon, CouponDto>();
            });

            return mappingConfig;
        }
    }
}
