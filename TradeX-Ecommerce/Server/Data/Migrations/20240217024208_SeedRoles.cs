using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TradeXEcommerce.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8bba161f-bcc3-47cf-84b6-80b11eb48eff", "07dcbc29-f203-4319-8065-a4d4ad5c8301", "Admin", "ADMIN" },
                    { "d6d3a996-7738-4c1a-bfe3-b4ab8b5fb502", "d44ddaf6-fbbd-48bc-9e3f-a5e2d10f4608", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bba161f-bcc3-47cf-84b6-80b11eb48eff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d6d3a996-7738-4c1a-bfe3-b4ab8b5fb502");
        }
    }
}
