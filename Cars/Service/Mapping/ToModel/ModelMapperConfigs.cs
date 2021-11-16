using AutoMapper;
using Cars.Domain.Entities;
using Cars.Domain.Models;

namespace Cars.Service.Mapping.ToModel
{
    public static class ModelMapperConfigs
    {
        public static void ApplyConfiguration(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CarModel, Car>();
            cfg.CreateMap<UserModel, User>();
        }
    }
}