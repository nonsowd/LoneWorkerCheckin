using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoneWorkerCheckin.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("0b6ddb7e-af14-4662-86c6-82b60ea2e442"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("1440eec7-5c8b-47d8-a56b-e14cd8ba721f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("52c20088-e5aa-4b48-8be5-6f646b4d985c"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("789166b2-eb77-4c7e-8536-cf173afc9936"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("78d78dcc-9361-42d4-b00d-5b9b3ccc413e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("ee11b5ba-cc38-4bae-99b4-ae91324e5178"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("f00995d7-97f5-42ff-b4ad-a0bc58f67d2d"));

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.SiteId);
                    table.ForeignKey(
                        name: "FK_Sites_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "RegionId");
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "RegionName" },
                values: new object[,]
                {
                    { new Guid("135c06f2-7caf-4fbf-bcfe-9cbbe4beb67e"), "Wales" },
                    { new Guid("278ad6af-b008-403d-a25f-a249cd6e6351"), "Southern" },
                    { new Guid("45d2fd15-f2c7-4eb0-adf9-87ef939d17fe"), "Middle England" },
                    { new Guid("566c89af-b5fd-4aeb-a93c-1f942c80d33b"), "Northern" },
                    { new Guid("810411d4-5f2f-46af-9400-972e50a77281"), "Scotland" },
                    { new Guid("c56db57a-e902-45bf-a56c-b38143fa80d2"), "South East" },
                    { new Guid("eb1057b5-8255-43c0-9796-02bbe47c1d45"), "South West" }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "SiteId", "RegionId", "SiteName" },
                values: new object[,]
                {
                    { new Guid("01ff832c-6f4f-4750-9065-0539bb380505"), new Guid("c56db57a-e902-45bf-a56c-b38143fa80d2"), "Brighton" },
                    { new Guid("1be49094-cfed-4743-9d29-df49d3d924b5"), new Guid("135c06f2-7caf-4fbf-bcfe-9cbbe4beb67e"), "Bangor" },
                    { new Guid("b4200663-b5d1-40f2-8603-d5a2f6e2cf1a"), new Guid("c56db57a-e902-45bf-a56c-b38143fa80d2"), "Horsham" },
                    { new Guid("c1870ae7-fe5a-4c9b-8c0e-fb2d874aabab"), new Guid("135c06f2-7caf-4fbf-bcfe-9cbbe4beb67e"), "Cardiff" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Regions_RegionName",
                table: "Regions",
                column: "RegionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sites_RegionId",
                table: "Sites",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_SiteName",
                table: "Sites",
                column: "SiteName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropIndex(
                name: "IX_Regions_RegionName",
                table: "Regions");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("135c06f2-7caf-4fbf-bcfe-9cbbe4beb67e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("278ad6af-b008-403d-a25f-a249cd6e6351"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("45d2fd15-f2c7-4eb0-adf9-87ef939d17fe"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("566c89af-b5fd-4aeb-a93c-1f942c80d33b"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("810411d4-5f2f-46af-9400-972e50a77281"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("c56db57a-e902-45bf-a56c-b38143fa80d2"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("eb1057b5-8255-43c0-9796-02bbe47c1d45"));

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
    }
}
