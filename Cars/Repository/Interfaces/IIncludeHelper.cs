using System.Linq;

namespace Cars.Repository
{
    public interface IIncludeHelper<T>
    {
        public IQueryable<T> Include(IQueryable<T> query);
    }
}