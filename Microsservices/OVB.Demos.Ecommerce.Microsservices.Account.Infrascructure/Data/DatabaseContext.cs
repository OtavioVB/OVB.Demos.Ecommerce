using Microsoft.EntityFrameworkCore;
using OVB.Core.Infrascructure.CrossCutting.Abstractions.Mappings;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObjects;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data;

public class DatabaseContext : DbContext
{
    public DbSet<AccountDataTransfer> Accounts { get; protected set; }

    private readonly BaseMapping<AccountDataTransfer> _accountBaseMapping;

    public DatabaseContext(BaseMapping<AccountDataTransfer> accountBaseMapping, DbContextOptions options) : base(options)
    {
        _accountBaseMapping = accountBaseMapping;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _accountBaseMapping.CreateMapping(modelBuilder.Entity<AccountDataTransfer>());

        base.OnModelCreating(modelBuilder);
    }
}
