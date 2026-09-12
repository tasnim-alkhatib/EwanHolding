using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EwanHolding.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixUniqueIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stats_DisplayOrder",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_CoreValues_DisplayOrder",
                table: "CoreValues");

            migrationBuilder.DropIndex(
                name: "IX_CoreValues_IconUrl",
                table: "CoreValues");

            migrationBuilder.DropIndex(
                name: "IX_Companies_LogoUrl",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_WebsiteUrl",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Admins_FullName",
                table: "Admins");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Stats_DisplayOrder",
                table: "Stats",
                column: "DisplayOrder",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoreValues_DisplayOrder",
                table: "CoreValues",
                column: "DisplayOrder",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoreValues_IconUrl",
                table: "CoreValues",
                column: "IconUrl",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_LogoUrl",
                table: "Companies",
                column: "LogoUrl",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_WebsiteUrl",
                table: "Companies",
                column: "WebsiteUrl",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Admins_FullName",
                table: "Admins",
                column: "FullName",
                unique: true);
        }
    }
}
