using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Mapping;

public sealed class AccountMapping : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        // Primary Key
        builder.HasKey(p => p.Identifier).HasName($"PK_{nameof(Account)}_{nameof(Account.Identifier)}");

        // Foreign Key
        builder.HasOne(p => p.User).WithOne(p => p.Account).HasForeignKey<User>(p => p.AccountIdentifier);

        // Index
        builder.HasIndex(p => p.Cpf).IsUnique().HasDatabaseName($"UK_{nameof(Account)}_{nameof(Account.Cpf)}");

        // Properties
        builder.Property(p => p.Cpf)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnType("CHAR(11)")
            .HasColumnName(nameof(Account.Cpf))
            .HasMaxLength(11);
    }
}
