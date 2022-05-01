using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Analysis.API.Migrations
{
    public partial class PercentageAllocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PercentAllocation",
                table: "Stocks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PercentAllocation",
                table: "Stocks");
        }
    }
}
