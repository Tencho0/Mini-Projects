namespace Mango.Services.OrderApi
{
    using AutoMapper;

    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {

            });

            return mappingConfig;
        }
    }
}
