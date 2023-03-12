using Microsoft.EntityFrameworkCore;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories.Extensions;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Repositories;

public sealed class UserRepository : BaseRepository<User>, IExtensionUserRepository
{
    public UserRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public Task<bool> VerifyUserExistsByUsernameOrEmail(string username, string email, CancellationToken cancellationToken)
    {
        return _dataContext.Set<User>().Where(p => p.Username == username || p.Email == email).AnyAsync(cancellationToken);
    }
}
