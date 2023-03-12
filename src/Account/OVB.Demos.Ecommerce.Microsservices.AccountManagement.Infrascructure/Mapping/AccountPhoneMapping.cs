using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountPhoneContext.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Mapping;

public sealed class AccountPhoneMapping : IEntityTypeConfiguration<AccountPhone>
{
    public void Configure(EntityTypeBuilder<AccountPhone> builder)
    {
        // Primary Key
        builder.HasKey(p => p.Identifier).HasName($"PK_{nameof(AccountPhone)}_{nameof(AccountPhone.Identifier)}");

        // Foreign Key
        builder.HasOne(p => p.Account).WithMany(p => p.AccountPhones);

        // Index
        builder.HasIndex(p => p.Identifier).IsUnique().HasDatabaseName($"UK_{nameof(AccountPhone)}_{nameof(AccountPhone.Identifier)}");

        // Properties
        builder.Property(p => p.Phone)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnType("CHAR")
            .HasColumnName(nameof(AccountPhone.Phone))
            .HasMaxLength(Phone.Length)
            .IsFixedLength();

    }
}
