using Microsoft.EntityFrameworkCore;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure;

public sealed class DataContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
