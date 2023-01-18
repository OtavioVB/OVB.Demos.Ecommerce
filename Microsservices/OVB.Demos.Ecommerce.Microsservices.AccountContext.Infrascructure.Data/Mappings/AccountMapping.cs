using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Domain.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Mappings.Interfaces;

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.Infrascructure.Data.Mappings;

public sealed class AccountMapping : IMapping<Account>
{
    public void CreateMapping(EntityTypeBuilder<Account> entity)
    {
        // Primary Key
        entity.HasKey(p => p.Identifier).HasName($"PK_ACCOUNT_IDENTIFIER");

        // Foreign Key

        // Index
        entity.HasIndex(p => p.Identifier)
            .IsUnique()
            .HasDatabaseName("UK_ACCOUNT_IDENTIFIER");

        entity.HasIndex(p => new { p.Username, p.Email })
            .IsUnique()
            .HasDatabaseName("UK_ACCOUNT_EMAIL_USERNAME");

        // Properties
        entity.Property(p => p.Username)
            .IsRequired()
            .HasColumnName("Username")
            .HasColumnType("VARCHAR")
            .HasMaxLength(256);

        entity.Property(p => p.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(256);

        entity.Property(p => p.Password)
            .IsRequired()
            .HasColumnName(@"Password")
            .HasColumnType("VARCHAR")
            .HasMaxLength(64);
    }
}
