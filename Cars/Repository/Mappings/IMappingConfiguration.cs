using Microsoft.EntityFrameworkCore;

namespace Cars.Repository.Mappings
{
    public interface IMappingConfiguration
    {
        void ApplyConfiguration(ModelBuilder builder);
    }
}