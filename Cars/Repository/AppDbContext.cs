using System;
using System.Linq;
using System.Reflection;
using Cars.Domain.Entities;
using Cars.Repository.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Cars.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var mapTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(IMappingConfiguration).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract);

            foreach (var type in mapTypes)
            {
                var mapInstance = (IMappingConfiguration)Activator.CreateInstance(type)!;
                mapInstance.ApplyConfiguration(builder);
            }
        }

        #region Entities

        public DbSet<Car> Cars;
        public DbSet<User> Users;

        #endregion
    }
}