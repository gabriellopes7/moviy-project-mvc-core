using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moviy.Data.Migrations
{
    public partial class AddBusNumberInBus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusNumber",
                table: "Buses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusNumber",
                table: "Buses");
        }
    }
}
