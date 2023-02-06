using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Demos.Ecommerce.Microsservices.Account.Domain.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Mapping;

public sealed class AccountConfiguration 
{
    public void Configure(EntityTypeBuilder<AccountDataTransfer> builder)
    {
        // Primary Key
        builder.HasKey(p => p.Identifier).HasName("PK_ACCOUNT_IDENTIFIER");

        // Index
        builder.HasIndex(p => new
        {
            p.TenantIdentifier,
            p.Username,
            p.Email,
        }).IsUnique().HasDatabaseName("UK_UNIQUE_ACCOUNT");

        // Foreign Keys

        // Properties
        builder.Property(p => p.Name)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(256);

        builder.Property(p => p.LastName)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(256);

        builder.Property(p => p.Email)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(256);

        builder.Property(p => p.Password)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(256);

        builder.Property(p => p.Username)
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasMaxLength(256);
    }
}
