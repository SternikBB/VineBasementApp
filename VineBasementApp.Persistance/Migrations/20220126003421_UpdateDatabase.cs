using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VineBasementApp.Persistance.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Vb_VineyardName",
                table: "Vb_Vineyards",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Vb_YearOfBottling",
                table: "Vb_Vines",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Vb_VineName",
                table: "Vb_Vines",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "Vb_PurchasePrice",
                table: "Vb_Vines",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Vb_AlcoholPercentage",
                table: "Vb_Vines",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Vb_Acidity",
                table: "Vb_Vines",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateIndex(
                name: "IX_Vb_Vineyards_Vb_VineyardName",
                table: "Vb_Vineyards",
                column: "Vb_VineyardName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vb_Vines_Vb_VineName",
                table: "Vb_Vines",
                column: "Vb_VineName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vb_Vineyards_Vb_VineyardName",
                table: "Vb_Vineyards");

            migrationBuilder.DropIndex(
                name: "IX_Vb_Vines_Vb_VineName",
                table: "Vb_Vines");

            migrationBuilder.AlterColumn<string>(
                name: "Vb_VineyardName",
                table: "Vb_Vineyards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Vb_YearOfBottling",
                table: "Vb_Vines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Vb_VineName",
                table: "Vb_Vines",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<float>(
                name: "Vb_PurchasePrice",
                table: "Vb_Vines",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "Vb_AlcoholPercentage",
                table: "Vb_Vines",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<float>(
                name: "Vb_Acidity",
                table: "Vb_Vines",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
