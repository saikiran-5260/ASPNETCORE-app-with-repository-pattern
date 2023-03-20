using ASPNETCORE_app_with_repository_pattern.Model;
using ASPNETCORE_app_with_repository_pattern.Model.DTO;
using AutoMapper;

namespace ASPNETCORE_app_with_repository_pattern
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMapper()
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<VehcileDto, Vehicle>();
                config.CreateMap<Vehicle, VehcileDto>();
            });
            return mapper;
        }
    }
}
