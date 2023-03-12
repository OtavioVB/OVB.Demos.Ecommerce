using Microsoft.EntityFrameworkCore;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountAddressContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountPhoneContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Mapping;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure;

public sealed class DataContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountAddress> AccountAddresses { get; set; }
    public DbSet<AccountPhone> AccountPhones { get; set; }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountMapping());
        modelBuilder.ApplyConfiguration(new AccountAddressMapping());
        modelBuilder.ApplyConfiguration(new AccountPhoneMapping());
        modelBuilder.ApplyConfiguration(new UserMapping());
        base.OnModelCreating(modelBuilder);
    }
}
