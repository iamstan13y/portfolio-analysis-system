using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Analysis.API.Migrations
{
    public partial class StockNewColumnsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PercentAllocation",
                table: "Stocks",
                newName: "PercentageRisk");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Stocks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CompanyCode",
                table: "Stocks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "CompanyCode",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "PercentageRisk",
                table: "Stocks",
                newName: "PercentAllocation");
        }
    }
}