using Microsoft.EntityFrameworkCore;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Repository.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Repository.Base;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
{
    protected readonly DataContext _dataContext;

    protected BaseRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task AddAsync(TEntity entity)
    {
        try
        {
            await _dataContext.Set<TEntity>().AddAsync(entity);
        }
        catch
        {
            throw;
        }
    }

    public async Task AddRangeAsync(List<TEntity> entity)
    {
        try
        {
            await _dataContext.Set<TEntity>().AddRangeAsync(entity);
        }
        catch
        {
            throw;
        }
    }

    public void Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void DeleteRange(List<TEntity> entity)
    {
        throw new NotImplementedException();
    }

    public async Task<List<TEntity>> GetByPaginationAsync(int index, int offset)
    {
        return await _dataContext.Set<TEntity>().Skip(index * offset).Take(offset).ToListAsync();
    }

    public void Update(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public void UpdateRange(List<TEntity> entity)
    {
        throw new NotImplementedException();
    }
}
