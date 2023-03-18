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
        builder.HasOne(p => p.User).WithOne(p => p.Account).HasForeignKey<Account>(p => p.UserIdentifier);
        builder.HasOne(p => p.AccountAddress).WithMany(p => p.Accounts);
        builder.HasMany(p => p.AccountPhones).WithOne(p => p.Account);

        // Index
        builder.HasIndex(p => p.Cpf).IsUnique().HasDatabaseName($"UK_{nameof(Account)}_{nameof(Account.Cpf)}");

        // Properties
        builder.Property(p => p.Cpf)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnType("CHAR")
            .HasColumnName(nameof(Account.Cpf))
            .HasMaxLength(Cpf.Length)
            .IsFixedLength(true);

        builder.Property(p => p.GeneralRegistry)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnType("CHAR")
            .HasColumnName(nameof(Account.GeneralRegistry))
            .HasMaxLength(GeneralRegistry.Length)
            .IsFixedLength(true);

        builder.Property(p => p.TenantIdentifier)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName(nameof(Account.TenantIdentifier))
            .HasColumnType("UUID")
            .IsFixedLength(true);

        builder.Property(p => p.CorrelationIdentifier)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName(nameof(Account.CorrelationIdentifier))
            .HasColumnType("UUID")
            .IsFixedLength(true);

        builder.Property(p => p.SourcePlatform)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName(nameof(Account.SourcePlatform))
            .HasMaxLength(SourcePlatform.MaxLength);

        builder.Property(p => p.AddressComplement)
            .ValueGeneratedNever()
            .HasColumnType("VARCHAR")
            .IsRequired(false)
            .HasColumnName(nameof(Account.AddressComplement))
            .HasMaxLength(AddressComplement.MaxLength);
    }
}
