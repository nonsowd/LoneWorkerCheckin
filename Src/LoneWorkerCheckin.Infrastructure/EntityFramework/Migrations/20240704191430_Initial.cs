using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoneWorkerCheckin.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "RegionName" },
                values: new object[,]
                {
                    { new Guid("0b6ddb7e-af14-4662-86c6-82b60ea2e442"), "South East" },
                    { new Guid("1440eec7-5c8b-47d8-a56b-e14cd8ba721f"), "South West" },
                    { new Guid("52c20088-e5aa-4b48-8be5-6f646b4d985c"), "Middle England" },
                    { new Guid("789166b2-eb77-4c7e-8536-cf173afc9936"), "Wales" },
                    { new Guid("78d78dcc-9361-42d4-b00d-5b9b3ccc413e"), "Southern" },
                    { new Guid("ee11b5ba-cc38-4bae-99b4-ae91324e5178"), "Scotland" },
                    { new Guid("f00995d7-97f5-42ff-b4ad-a0bc58f67d2d"), "Northern" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
