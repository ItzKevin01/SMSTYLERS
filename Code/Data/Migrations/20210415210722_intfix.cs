using Microsoft.EntityFrameworkCore.Migrations;

namespace smstylers.Data.Migrations
{
    public partial class intfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Prijs",
                table: "Surfboards",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decilmal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Prijs",
                table: "Surfboards",
                type: "decilmal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
