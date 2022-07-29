using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace tabeshyar_back.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected TabeshyarDb RepositoryContext { get; set; } = default!;
        public readonly IMapper _mapper;
        public RepositoryBase(TabeshyarDb repositoryContext, IMapper mapper)
        {
            RepositoryContext = repositoryContext;
            _mapper = mapper;
        }
        public async Task CreateAsync(T entity)
        {
            if(entity == null)
                throw new ArgumentNullException(paramName: nameof(entity));
            await RepositoryContext.Set<T>().AddAsync(entity);
        }
        public async Task CreateRangeAsync(List<T> entities)
        {
            if (entities.Count < 1)
                throw new ArgumentOutOfRangeException(paramName: nameof(entities));
            await RepositoryContext.Set<T>().AddRangeAsync(entities);
        }
        public async Task UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(paramName: nameof(entity));
            }

            await Task.Run(() =>
            {
                this.RepositoryContext.Set<T>().Update(entity);
            });
        }
        public IQueryable<T> GetByQuery()
        {
            return this.RepositoryContext.Set<T>().AsNoTracking();
        }
    }
}
