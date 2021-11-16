using Cars.Domain.Entities;
using Cars.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cars.Repository.Mappings
{
    public class CarMap : IMappingConfiguration
    {
        public void ApplyConfiguration(ModelBuilder builder)
        {
            builder.Entity<Car>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PlateNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasConversion(new EnumToStringConverter<MakeEnum>());
            });
        }
    }
}