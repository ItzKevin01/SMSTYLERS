using Microsoft.EntityFrameworkCore.Migrations;

namespace smstylers.Data.Migrations
{
    public partial class migone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filialen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filialen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surfboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prijs = table.Column<decimal>(type: "int", nullable: false),
                    AfbeeldingsUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MateriaalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surfboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Voorraad",
                columns: table => new
                {
                    SurfboardId = table.Column<int>(type: "int", nullable: false),
                    FiliaalId = table.Column<int>(type: "int", nullable: false),
                    Aantal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voorraad", x => new { x.SurfboardId, x.FiliaalId });
                    table.ForeignKey(
                        name: "FK_Voorraad_Filialen_FiliaalId",
                        column: x => x.FiliaalId,
                        principalTable: "Filialen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Voorraad_Surfboards_SurfboardId",
                        column: x => x.SurfboardId,
                        principalTable: "Surfboards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Voorraad_FiliaalId",
                table: "Voorraad",
                column: "FiliaalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Voorraad");

            migrationBuilder.DropTable(
                name: "Filialen");

            migrationBuilder.DropTable(
                name: "Surfboards");
        }
    }
}
