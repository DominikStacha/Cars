using AutoMapper;
using Cars.Service.Mapping.ToEntity;
using Cars.Service.Mapping.ToModel;

namespace Cars.Service.Mapping
{
    public class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; private set; }
        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void Init()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                EntityMapperConfigs.ApplyConfiguration(cfg);
                ModelMapperConfigs.ApplyConfiguration(cfg);
            });

            Mapper = MapperConfiguration.CreateMapper();
        }
    }
}