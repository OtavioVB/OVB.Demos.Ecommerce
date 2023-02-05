using Microsoft.EntityFrameworkCore;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Mapping;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data;

public sealed class DataContext : DbContext
{
    public DbSet<AccountDataTransfer> Accounts { get; protected set; }

    public DataContext(DbContextOptions options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new AccountConfiguration().Configure(modelBuilder.Entity<AccountDataTransfer>());
        base.OnModelCreating(modelBuilder);
    }
}
