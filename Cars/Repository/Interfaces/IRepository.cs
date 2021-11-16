using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Domain.Base;

namespace Cars.Repository.Interfaces
{
    public interface IRepository<T> where T : EntityId
    {
        IQueryable<T> ApplyInclude(IQueryable<T> query);
        Task<ICollection<T>> GetAll(bool include = true);
        IQueryable<T> GetAllAsQueryable(bool include = true);
        Task<T> Get(long id, bool include = true);
        Task<T> Insert(T entity);
        Task<T> Update(T entity);
        Task DeleteById(long id);
    }
}