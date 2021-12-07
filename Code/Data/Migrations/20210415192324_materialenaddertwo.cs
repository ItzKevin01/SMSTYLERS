using Microsoft.EntityFrameworkCore.Migrations;

namespace smstylers.Data.Migrations
{
    public partial class materialenaddertwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materiaal",
                columns: table => new
                {
                    MateriaalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiaal", x => x.MateriaalId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Surfboards_MateriaalId",
                table: "Surfboards",
                column: "MateriaalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Surfboards_Materiaal_MateriaalId",
                table: "Surfboards",
                column: "MateriaalId",
                principalTable: "Materiaal",
                principalColumn: "MateriaalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Surfboards_Materiaal_MateriaalId",
                table: "Surfboards");

            migrationBuilder.DropTable(
                name: "Materiaal");

            migrationBuilder.DropIndex(
                name: "IX_Surfboards_MateriaalId",
                table: "Surfboards");
        }
    }
}
