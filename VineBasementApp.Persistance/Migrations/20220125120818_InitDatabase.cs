using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VineBasementApp.Persistance.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vb_Vineyards",
                columns: table => new
                {
                    Vb_VineyardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vb_VineyardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vb_VineyardCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vb_VineyardRegion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vb_VineyardCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vb_VineyardYearOfFoundation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vb_Vineyards", x => x.Vb_VineyardId);
                });

            migrationBuilder.CreateTable(
                name: "Vb_Vines",
                columns: table => new
                {
                    Vb_VineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vb_VineName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vb_VineColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vb_VineType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vb_VineyardId = table.Column<int>(type: "int", nullable: false),
                    Vb_YearOfBottling = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vb_AlcoholPercentage = table.Column<float>(type: "real", nullable: false),
                    Vb_Acidity = table.Column<float>(type: "real", nullable: false),
                    Vb_PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vb_PurchasePrice = table.Column<float>(type: "real", nullable: false),
                    Vb_AmountOfPurchasedBottles = table.Column<int>(type: "int", nullable: false),
                    Vb_AmountOfOwnedBottles = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vb_Vines", x => x.Vb_VineId);
                    table.ForeignKey(
                        name: "FK_Vb_Vines_Vb_Vineyards_Vb_VineyardId",
                        column: x => x.Vb_VineyardId,
                        principalTable: "Vb_Vineyards",
                        principalColumn: "Vb_VineyardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vb_Vines_Vb_VineyardId",
                table: "Vb_Vines",
                column: "Vb_VineyardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vb_Vines");

            migrationBuilder.DropTable(
                name: "Vb_Vineyards");
        }
    }
}
