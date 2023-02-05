using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OVB.Demos.Ecommerce.Microsservices.Account.Infrascructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class BaseMigratio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    Username = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    TypeAccount = table.Column<int>(type: "integer", nullable: false),
                    TenantIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    CorrelationIdentifier = table.Column<Guid>(type: "uuid", nullable: false),
                    SourcePlatform = table.Column<string>(type: "text", nullable: false),
                    ExecutionUser = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT_IDENTIFIER", x => x.Identifier);
                });

            migrationBuilder.CreateIndex(
                name: "UK_UNIQUE_ACCOUNT",
                table: "Accounts",
                columns: new[] { "TenantIdentifier", "Username", "Email" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
