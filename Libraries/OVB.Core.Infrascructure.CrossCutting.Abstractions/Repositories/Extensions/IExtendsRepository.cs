using OVB.Core.Domain.CrossCutting.Abstractions.DataTransferObjects;

namespace OVB.Core.Infrascructure.CrossCutting.Abstractions.Repositories.Extensions;

public interface IExtendsRepository<T> : IBaseRepository<T> 
    where T : IDataTransferObject
{
    Task<bool> VerifyEntityExistsAsync(Guid identifier);
}
