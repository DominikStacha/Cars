using System.Linq;
using Cars.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.Repository.IncludeHelpers
{
    public class CarIncludeHelper : IIncludeHelper<Car>
    {
        public IQueryable<Car> Include(IQueryable<Car> query)
        {
            return query.Include(e => e.User);
        }
    }
}