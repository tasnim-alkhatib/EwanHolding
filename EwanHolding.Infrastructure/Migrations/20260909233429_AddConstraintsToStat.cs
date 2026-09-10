using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EwanHolding.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConstraintsToStat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Stats",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Label_En",
                table: "Stats",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Label_Ar",
                table: "Stats",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Stats_DisplayOrder",
                table: "Stats",
                column: "DisplayOrder",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_Label_Ar",
                table: "Stats",
                column: "Label_Ar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stats_Label_En",
                table: "Stats",
                column: "Label_En",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stats_DisplayOrder",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_Label_Ar",
                table: "Stats");

            migrationBuilder.DropIndex(
                name: "IX_Stats_Label_En",
                table: "Stats");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Stats",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Label_En",
                table: "Stats",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Label_Ar",
                table: "Stats",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
