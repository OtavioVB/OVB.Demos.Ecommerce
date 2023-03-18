using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OVB.Demos.Ecommerce.Microsservices.AccountManagement.Infrascructure.Migrations
{
    /// <inheritdoc />
    public partial class BaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountAddresses",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    StreetName = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    Neighborhood = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    City = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    State = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    Country = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    PostalCode = table.Column<string>(type: "CHAR(8)", fixedLength: true, maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountAddress_Identifier", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "VARCHAR", maxLength: 24, nullable: false),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR", maxLength: 32, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    TypeUser = table.Column<short>(type: "SMALLINT", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "BOOLEAN", fixedLength: true, nullable: false),
                    TenantIdentifier = table.Column<Guid>(type: "UUID", fixedLength: true, nullable: false),
                    CorrelationIdentifier = table.Column<Guid>(type: "UUID", fixedLength: true, nullable: false),
                    SourcePlatform = table.Column<string>(type: "VARCHAR", maxLength: 32, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Identifier", x => x.Identifier);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    Cpf = table.Column<string>(type: "CHAR(11)", fixedLength: true, maxLength: 11, nullable: false),
                    GeneralRegistry = table.Column<string>(type: "CHAR(9)", fixedLength: true, maxLength: 9, nullable: false),
                    AddressComplement = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: true),
                    AccountAddressIdentifier = table.Column<Guid>(type: "uuid", nullable: true),
                    UserIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    TenantIdentifier = table.Column<Guid>(type: "UUID", fixedLength: true, nullable: false),
                    CorrelationIdentifier = table.Column<Guid>(type: "UUID", fixedLength: true, nullable: false),
                    SourcePlatform = table.Column<string>(type: "VARCHAR", maxLength: 32, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account_Identifier", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountAddresses_AccountAddressIdentifier",
                        column: x => x.AccountAddressIdentifier,
                        principalTable: "AccountAddresses",
                        principalColumn: "Identifier");
                    table.ForeignKey(
                        name: "FK_Accounts_Users_UserIdentifier",
                        column: x => x.UserIdentifier,
                        principalTable: "Users",
                        principalColumn: "Identifier",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountPhones",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    Phone = table.Column<string>(type: "CHAR(11)", fixedLength: true, maxLength: 11, nullable: false),
                    AccountIdentifier = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountPhone_Identifier", x => x.Identifier);
                    table.ForeignKey(
                        name: "FK_AccountPhones_Accounts_AccountIdentifier",
                        column: x => x.AccountIdentifier,
                        principalTable: "Accounts",
                        principalColumn: "Identifier");
                });

            migrationBuilder.CreateIndex(
                name: "UK_AccountAddress_PostalCode",
                table: "AccountAddresses",
                column: "PostalCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccountPhones_AccountIdentifier",
                table: "AccountPhones",
                column: "AccountIdentifier");

            migrationBuilder.CreateIndex(
                name: "UK_AccountPhone_Identifier",
                table: "AccountPhones",
                column: "Identifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountAddressIdentifier",
                table: "Accounts",
                column: "AccountAddressIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_UserIdentifier",
                table: "Accounts",
                column: "UserIdentifier",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Account_Cpf",
                table: "Accounts",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_User_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_User_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountPhones");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AccountAddresses");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
