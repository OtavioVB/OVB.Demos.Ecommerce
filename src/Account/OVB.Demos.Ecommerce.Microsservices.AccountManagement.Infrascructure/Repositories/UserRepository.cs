using Microsoft.EntityFrameworkCore;
using Npgsql;
using OVB.Demos.Ecommerce.Libraries.Infrascructure.RetryPattern.Interfaces;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Extensions;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories;

public sealed class UserRepository : BaseRepository<User>, IExtensionUserRepository
{
    public UserRepository(DataContext dataContext, IRetry retry) : base(dataContext, retry)
    {
    }

    public Task<bool> VerifyUserExistsByUsernameOrEmail(string username, string email, CancellationToken cancellationToken)
    {
        var localResponse = _retry.TryRetry<bool, NpgsqlException, PostgresException>(() =>
        {
            return _dataContext.Set<User>().Local.Where(p => p.Username == username || p.Email == email).Any();
        });
        
        if (localResponse)
            return Task.FromResult(true);

        return _retry.TryRetry<Task<bool>, NpgsqlException, PostgresException>(() =>
        {
            return _dataContext.Set<User>().Where(p => p.Username == username || p.Email == email).AnyAsync(cancellationToken);
        });
    }
}
