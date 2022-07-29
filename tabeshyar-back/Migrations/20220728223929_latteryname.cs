using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tabeshyar_back.Migrations
{
    public partial class latteryname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LatteryName",
                table: "LatteryCodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatteryName",
                table: "LatteryCodes");
        }
    }
}
