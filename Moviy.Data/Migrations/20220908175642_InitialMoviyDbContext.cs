using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moviy.Data.Migrations
{
    public partial class InitialMoviyDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicensePlate = table.Column<string>(type: "varchar(7)", nullable: false),
                    BusColor = table.Column<int>(type: "int", nullable: false),
                    BusSize = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeactivatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverLicense = table.Column<string>(type: "varchar(11)", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Document = table.Column<string>(type: "varchar(8)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    Image = table.Column<string>(type: "varchar(100)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeactivatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "varchar(200)", nullable: false),
                    City = table.Column<string>(type: "varchar(100)", nullable: false),
                    District = table.Column<string>(type: "varchar(200)", nullable: false),
                    Street = table.Column<string>(type: "varchar(200)", nullable: false),
                    Number = table.Column<string>(type: "varchar(50)", nullable: false),
                    Code = table.Column<string>(type: "varchar(8)", nullable: false),
                    State = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineRoutes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartPointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LinePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Line = table.Column<string>(type: "varchar(100)", nullable: false),
                    EndPointId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ActivatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeactivatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineRoutes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineRoutes_Locals_EndPointId",
                        column: x => x.EndPointId,
                        principalTable: "Locals",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LineRoutes_Locals_StartPointId",
                        column: x => x.StartPointId,
                        principalTable: "Locals",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Travels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LineRouteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Travels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Travels_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Travels_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Travels_LineRoutes_LineRouteId",
                        column: x => x.LineRouteId,
                        principalTable: "LineRoutes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineRoutes_EndPointId",
                table: "LineRoutes",
                column: "EndPointId");

            migrationBuilder.CreateIndex(
                name: "IX_LineRoutes_StartPointId",
                table: "LineRoutes",
                column: "StartPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_BusId",
                table: "Travels",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_DriverId",
                table: "Travels",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Travels_LineRouteId",
                table: "Travels",
                column: "LineRouteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Travels");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "LineRoutes");

            migrationBuilder.DropTable(
                name: "Locals");
        }
    }
}
