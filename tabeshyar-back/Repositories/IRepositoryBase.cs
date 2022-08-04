namespace tabeshyar_back.Repositories
{
    public interface IRepositoryBase<T>
    {
        Task CreateAsync(T entity);
        Task CreateRangeAsync(List<T> entities);
        Task UpdateAsync(T entity);
        IQueryable<T> GetByQuery();
    }
}
