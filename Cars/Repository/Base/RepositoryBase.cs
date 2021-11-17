using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cars.Domain.Base;
using Cars.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cars.Repository.Base
{
    public class RepositoryBase<T> : IRepository<T> where T : EntityId
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<T> _entitySet;
        protected readonly IIncludeHelper<T> _includeHelper;

        public RepositoryBase(AppDbContext dbContext, IServiceProvider diContainer)
        {
            _dbContext = dbContext;
            _entitySet = _dbContext.Set<T>();
            _includeHelper = (diContainer.GetService(typeof(IIncludeHelper<T>)) as IIncludeHelper<T>)!;
        }

        public IQueryable<T> ApplyInclude(IQueryable<T> query)
        {
            return _includeHelper.Include(query);
        }

        public async Task<ICollection<T>> GetAll(bool include = true)
        {
            var query = include ? _includeHelper.Include(_entitySet) : _entitySet;
            return await query.ToListAsync();
        }

        public IQueryable<T> GetAllAsQueryable(bool include = true)
        {
            var query = include ? _includeHelper.Include(_entitySet) : _entitySet;
            return query;
        }

        public async Task<T> Get(long id, bool include = true)
        {
            var query = include ? _includeHelper.Include(_entitySet) : _entitySet;
            query = query.Where(e => e.Id == id);
            return (await query.SingleOrDefaultAsync())!;
        }

        public async Task<T> Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            var entry = await _entitySet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return await Get(entry.Entity.Id);
        }

        public async Task<T> Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _entitySet.Update(entity);
            await _dbContext.SaveChangesAsync();
            return await Get(entity.Id);
        }

        public async Task DeleteById(long id)
        {
            var entity = await _entitySet.FirstOrDefaultAsync(e => e.Id == id);
            _entitySet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}