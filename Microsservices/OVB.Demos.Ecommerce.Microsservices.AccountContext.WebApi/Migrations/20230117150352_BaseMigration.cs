using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OVB.Demos.Ecommerce.Microsservices.AccountContext.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class BaseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Identifier = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    Password = table.Column<string>(type: "VARCHAR", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "VARCHAR", maxLength: 256, nullable: false),
                    TypeAccount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT_IDENTIFIER", x => x.Identifier);
                });

            migrationBuilder.CreateIndex(
                name: "UK_ACCOUNT_EMAIL_USERNAME",
                table: "Account",
                columns: new[] { "Username", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_ACCOUNT_IDENTIFIER",
                table: "Account",
                column: "Identifier",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
