using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Core.Infrascructure.CrossCutting.Abstractions.Mappings;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObjects;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Mappings;

public class AccountBaseMapping : BaseMapping<AccountDataTransfer>
{
    protected new virtual void MappingOverrideExtensions(EntityTypeBuilder<AccountDataTransfer> builder)
    {
        base.MappingOverrideExtensions(builder);
    }
}
