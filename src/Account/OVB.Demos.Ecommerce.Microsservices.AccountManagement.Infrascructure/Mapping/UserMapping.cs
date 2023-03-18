using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OVB.Demos.Ecommerce.Libraries.Domain.ValueObjects;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.AccountContext.DataTransferObject;
using OVB.Demos.Ecommerce.Microsservices.AccountManagement.Domain.UserContext.DataTransferObject;

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Mapping;

public sealed class UserMapping : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Primary Key
        builder.HasKey(p => p.Identifier).HasName($"PK_{nameof(User)}_{nameof(User.Identifier)}");

        // Foreign Key
        builder.HasOne(p => p.Account).WithOne(p => p.User).HasForeignKey<Account>(p => p.UserIdentifier);

        // Index
        builder.HasIndex(p => p.Username).IsUnique().HasDatabaseName($"UK_{nameof(User)}_{nameof(User.Username)}");
        builder.HasIndex(p => p.Email).IsUnique().HasDatabaseName($"UK_{nameof(User)}_{nameof(User.Email)}");

        // Properties
        builder.Property(p => p.IsEmailConfirmed)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName(nameof(User.IsEmailConfirmed))
            .HasColumnType("BOOLEAN")
            .IsFixedLength();

        builder.Property(p => p.TypeUser)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName(nameof(User.TypeUser))
            .HasColumnType("SMALLINT");

        builder.Property(p => p.CreatedOn)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName(nameof(User.CreatedOn))
            .HasColumnType("TIMESTAMPTZ");

        builder.Property(p => p.TenantIdentifier)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName(nameof(User.TenantIdentifier))
            .HasColumnType("UUID")
            .IsFixedLength();

        builder.Property(p => p.CorrelationIdentifier)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnName(nameof(User.CorrelationIdentifier))
            .HasColumnType("UUID")
            .IsFixedLength();

        builder.Property(p => p.SourcePlatform)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName(nameof(User.SourcePlatform))
            .HasMaxLength(SourcePlatform.MaxLength);

        builder.Property(p => p.Username)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName(nameof(User.Username))
            .HasMaxLength(Username.MaxLength);

        builder.Property(p => p.Name)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName(nameof(User.Name))
            .HasMaxLength(Name.MaxLength);

        builder.Property(p => p.LastName)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName(nameof(User.LastName))
            .HasMaxLength(LastName.MaxLength);

        builder.Property(p => p.Email)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName(nameof(User.Email))
            .HasMaxLength(Email.MaxLength);

        builder.Property(p => p.Password)
            .ValueGeneratedNever()
            .IsRequired()
            .HasColumnType("VARCHAR")
            .HasColumnName(nameof(User.Password))
            .HasMaxLength(256);
    }
}
