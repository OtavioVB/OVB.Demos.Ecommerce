using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Core.Domain.CrossCuting.Abstractions.DataTransferObjects;
using OVB.Core.Domain.CrossCutting.Abstractions.DataTransferObjects;

namespace OVB.Core.Infrascructure.CrossCutting.Abstractions.Mappings;

public abstract class BaseMapping<T> where T : DataTransferObjectBase
{
    public void CreateMapping(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(p => p.Identifier);

        MappingOverrideExtensions(builder);
    }

    public virtual void MappingOverrideExtensions(EntityTypeBuilder<T> builder)
    {
        return;
    }
}
