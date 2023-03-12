using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountAddressContext.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Mapping;

public sealed class AccountAddressMapping : IEntityTypeConfiguration<AccountAddress>
{
    public void Configure(EntityTypeBuilder<AccountAddress> builder)
    {
        // Primary Key
        builder.HasKey(p => p.Identifier).HasName($"PK_{nameof(AccountAddress)}_{nameof(AccountAddress.Identifier)}");

        // Foreign Key
        builder.HasMany(p => p.Accounts).WithOne(p => p.AccountAddress);

        // Index
        builder.HasIndex(p => p.PostalCode).IsUnique().HasDatabaseName($"UK_{nameof(AccountAddress)}_{nameof(AccountAddress.PostalCode)}");

        // Properties
        builder.Property(p => p.PostalCode)
            .IsRequired()
            .ValueGeneratedNever()
            .HasColumnName(nameof(AccountAddress.PostalCode))
            .HasColumnType("CHAR")
            .HasMaxLength(PostalCode.Length)
            .IsFixedLength(true);

        builder.Property(p => p.StreetName)
            .IsRequired()
            .ValueGeneratedNever()
            .HasColumnName(nameof(AccountAddress.StreetName))
            .HasColumnType("VARCHAR")
            .HasMaxLength(StreetName.MaxLength);

        builder.Property(p => p.Neighborhood)
            .IsRequired()
            .ValueGeneratedNever()
            .HasColumnName(nameof(AccountAddress.Neighborhood))
            .HasColumnType("VARCHAR")
            .HasMaxLength(Neighborhood.MaxLength);

        builder.Property(p => p.State)
            .IsRequired()
            .ValueGeneratedNever()
            .HasColumnName(nameof(AccountAddress.State))
            .HasColumnType("VARCHAR")
            .HasMaxLength(State.MaxLength);

        builder.Property(p => p.City)
            .IsRequired()
            .ValueGeneratedNever()
            .HasColumnName(nameof(AccountAddress.City))
            .HasColumnType("VARCHAR")
            .HasMaxLength(City.MaxLength);

        builder.Property(p => p.Country)
            .IsRequired()
            .ValueGeneratedNever()
            .HasColumnName(nameof(AccountAddress.Country))
            .HasColumnType("VARCHAR")
            .HasMaxLength(Country.MaxLength);
    }
}
