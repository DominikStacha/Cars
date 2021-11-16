using System.Linq;
using Cars.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cars.Repository.IncludeHelpers
{
    public class UserIncludeHelper : IIncludeHelper<User>
    {
        public IQueryable<User> Include(IQueryable<User> query)
        {
            return query.Include(e => e.Cars);
        }
    }
}