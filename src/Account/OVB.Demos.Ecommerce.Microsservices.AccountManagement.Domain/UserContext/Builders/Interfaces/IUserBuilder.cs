using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Entities.Base;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.ENUMs;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.Builders.Interfaces;

public interface IUserBuilder
{
    public UserBase CreateUserDomainEntityByHisType(TypeUser typeUser);
}
