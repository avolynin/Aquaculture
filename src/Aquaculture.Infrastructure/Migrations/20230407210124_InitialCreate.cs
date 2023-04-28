using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aquaculture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FishInfomations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AvgWeight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishInfomations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FishTanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WaterMeasurementId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FishInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishTanks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaterMeasurements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FishTankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WaterParams_Temperature = table.Column<float>(type: "real", nullable: false),
                    WaterParams_DissolvedOxygen = table.Column<float>(type: "real", nullable: false),
                    WaterParams_Acidity = table.Column<float>(type: "real", nullable: false),
                    WaterParams_Alkalinity = table.Column<float>(type: "real", nullable: false),
                    WaterParams_CarbonDioxide = table.Column<float>(type: "real", nullable: false),
                    WaterParams_Ammonia = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterMeasurements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FishTypes",
                columns: table => new
                {
                    FishTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FishInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComfortParams_Temperature = table.Column<float>(type: "real", nullable: false),
                    ComfortParams_DissolvedOxygen = table.Column<float>(type: "real", nullable: false),
                    ComfortParams_Acidity = table.Column<float>(type: "real", nullable: false),
                    ComfortParams_Alkalinity = table.Column<float>(type: "real", nullable: false),
                    ComfortParams_CarbonDioxide = table.Column<float>(type: "real", nullable: false),
                    ComfortParams_Ammonia = table.Column<float>(type: "real", nullable: false),
                    TolerantParams_Temperature = table.Column<float>(type: "real", nullable: false),
                    TolerantParams_DissolvedOxygen = table.Column<float>(type: "real", nullable: false),
                    TolerantParams_Acidity = table.Column<float>(type: "real", nullable: false),
                    TolerantParams_Alkalinity = table.Column<float>(type: "real", nullable: false),
                    TolerantParams_CarbonDioxide = table.Column<float>(type: "real", nullable: false),
                    TolerantParams_Ammonia = table.Column<float>(type: "real", nullable: false),
                    CriticalParams_Temperature = table.Column<float>(type: "real", nullable: false),
                    CriticalParams_DissolvedOxygen = table.Column<float>(type: "real", nullable: false),
                    CriticalParams_Acidity = table.Column<float>(type: "real", nullable: false),
                    CriticalParams_Alkalinity = table.Column<float>(type: "real", nullable: false),
                    CriticalParams_CarbonDioxide = table.Column<float>(type: "real", nullable: false),
                    CriticalParams_Ammonia = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishTypes", x => new { x.FishTypeId, x.FishInfoId });
                    table.ForeignKey(
                        name: "FK_FishTypes_FishInfomations_FishInfoId",
                        column: x => x.FishInfoId,
                        principalTable: "FishInfomations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FishTypes_FishInfoId",
                table: "FishTypes",
                column: "FishInfoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FishTanks");

            migrationBuilder.DropTable(
                name: "FishTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WaterMeasurements");

            migrationBuilder.DropTable(
                name: "FishInfomations");
        }
    }
}
