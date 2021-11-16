using System.Collections.Generic;
using System.Threading.Tasks;
using Cars.Domain.Base;

namespace Cars.Service.Interfaces
{
    public interface IService<TEntity, TModel>
        where TEntity : EntityId
        where TModel : ModelId
    {
        Task<ICollection<TModel>> GetAllAsync();
        Task<TModel> GetByIdAsync(long itemId);
        Task<TModel> CreateAsync(TModel item);
        Task<TModel> UpdateAsync(TModel item);
        Task DeleteAsync(long id);
    }
}