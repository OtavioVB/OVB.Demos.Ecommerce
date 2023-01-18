using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Mappings.Interfaces;

public interface IMapping<TEntity>
    where TEntity : class
{
    public void CreateMapping(EntityTypeBuilder<TEntity> entity);
}
