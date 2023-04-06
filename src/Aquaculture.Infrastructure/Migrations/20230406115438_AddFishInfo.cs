using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aquaculture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddFishInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                name: "FishTypes");

            migrationBuilder.DropTable(
                name: "FishInfomations");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");
        }
    }
}
