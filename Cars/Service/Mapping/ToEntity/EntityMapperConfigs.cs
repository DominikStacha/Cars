using AutoMapper;
using Cars.Domain.Entities;
using Cars.Domain.Models;

namespace Cars.Service.Mapping.ToEntity
{
    public static class EntityMapperConfigs
    {
        public static void ApplyConfiguration(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Car, CarModel>();
            cfg.CreateMap<User, UserModel>();
        }
    }
}