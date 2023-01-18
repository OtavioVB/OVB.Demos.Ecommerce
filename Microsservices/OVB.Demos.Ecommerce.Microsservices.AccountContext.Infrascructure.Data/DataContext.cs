using Microsoft.EntityFrameworkCore;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Mappings.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data;

public class DataContext : DbContext
{
    public DbSet<Account> Account { get; protected set; }
    private readonly IMapping<Account> _mappingAccount;

    public DataContext(IMapping<Account> mappingAccount, DbContextOptions options) 
        : base(options)
    {
        _mappingAccount = mappingAccount;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        _mappingAccount.CreateMapping(modelBuilder.Entity<Account>());

        base.OnModelCreating(modelBuilder);
    }
}
