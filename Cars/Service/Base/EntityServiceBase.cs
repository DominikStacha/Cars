using System.Collections.Generic;
using System.Threading.Tasks;
using Cars.Domain.Base;
using Cars.Repository.Interfaces;
using Cars.Service.Interfaces;
using Cars.Service.Mapping;

namespace Cars.Service.Base
{
    public class EntityServiceBase<TEntity, TModel> : IService<TEntity, TModel>
        where TEntity : EntityId
        where TModel : ModelId
    {
        protected readonly IRepository<TEntity> _entityRepository;

        public EntityServiceBase(IRepository<TEntity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<ICollection<TModel>> GetAllAsync()
        {
            ICollection<TEntity> result = await _entityRepository.GetAll();
            return result.MapTo<ICollection<TEntity>, ICollection<TModel>>();
        }

        public async Task<TModel> GetByIdAsync(long itemId)
        {
            TEntity result = await _entityRepository.Get(itemId);
            return result.MapTo<TEntity, TModel>();
        }

        public async Task<TModel> CreateAsync(TModel item)
        {
            TEntity entity = item.MapTo<TModel, TEntity>();
            TEntity result = await _entityRepository.Insert(entity);
            return result.MapTo<TEntity, TModel>();
        }

        public async Task<TModel> UpdateAsync(TModel item)
        {
            TEntity entity = item.MapTo<TModel, TEntity>();
            TEntity result = await _entityRepository.Update(entity);
            return result.MapTo<TEntity, TModel>();
        }

        public async Task DeleteAsync(long id)
        {
            await _entityRepository.DeleteById(id);
        }
    }
}