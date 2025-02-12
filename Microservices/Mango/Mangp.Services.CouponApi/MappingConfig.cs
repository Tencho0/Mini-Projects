namespace Mangp.Services.CouponApi
{
    using AutoMapper;
    using Mangp.Services.CouponApi.Models;
    using Mangp.Services.CouponApi.Models.Dto;

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
