using OVB.Core.Domain.CrossCuting.Abstractions.DataTransferObjects;
using OVB.Core.Domain.CrossCutting.Abstractions.DataTransferObjects;

namespace OVB.Core.Infrascructure.CrossCutting.Abstractions.Repositories;

public interface IBaseRepository<T>
    where T : IDataTransferObject
{
    Task AddAsync(T entity);
    Task AddRangeAsync(List<T> entities);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
    Task<T?> GetByIdAsync(Guid identifier);
    Task<List<T>> GetAllAsync();
}
