using System.Runtime.InteropServices.ComTypes;
using Cars.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.Repository.Mappings
{
    public class UserMap : IMappingConfiguration
    {
        public void ApplyConfiguration(ModelBuilder builder)
        {
            builder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasIndex(e => e.Email)
                    .IsUnique();

                entity.HasMany(e => e.Cars)
                    .WithOne(e => e.User)
                    .HasForeignKey(e => e.Id)
                    .OnDelete(DeleteBehavior.NoAction);
            });
        }
    }
}