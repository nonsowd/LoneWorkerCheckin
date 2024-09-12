using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoneWorkerCheckin.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedLocations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: new Guid("eb1057b5-8255-43c0-9796-02bbe47c1d45"));

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "SiteId",
                keyValue: new Guid("01ff832c-6f4f-4750-9065-0539bb380505"));

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "SiteId",
                keyValue: new Guid("1be49094-cfed-4743-9d29-df49d3d924b5"));

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "SiteId",
                keyValue: new Guid("b4200663-b5d1-40f2-8603-d5a2f6e2cf1a"));

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "SiteId",
                keyValue: new Guid("c1870ae7-fe5a-4c9b-8c0e-fb2d874aabab"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("135c06f2-7caf-4fbf-bcfe-9cbbe4beb67e"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("c56db57a-e902-45bf-a56c-b38143fa80d2"));

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "LocationName" },
                values: new object[,]
                {
                    { new Guid("2ac4032b-240f-4029-9d64-d20848c8d694"), "Reception" },
                    { new Guid("6d55a9ed-e128-4366-97d0-eddcb6fa7c58"), "Dinning room" },
                    { new Guid("774e9499-fb15-4995-8dc8-43610a5f5b53"), "Kitchen" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "RegionName" },
                values: new object[,]
                {
                    { new Guid("04d82d36-3c9a-4b57-94f0-509574eb1523"), "Wales" },
                    { new Guid("0e817f5c-e063-4d2a-aca5-0e40b52dd0ce"), "Northern" },
                    { new Guid("6cc76f4a-5c6d-4f25-b898-0ffeaec0af1f"), "Scotland" },
                    { new Guid("7736d6df-d93d-42c8-82c3-639bfd7b326f"), "South East" },
                    { new Guid("7d45913f-2062-41e6-8da5-2d9f3b259552"), "South West" },
                    { new Guid("c5b96f86-2305-4a90-b3cf-cd8300c28017"), "Middle England" },
                    { new Guid("cd5aa765-ace1-4cf0-bd8d-141eca83a8e1"), "Southern" }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "SiteId", "RegionId", "SiteName" },
                values: new object[,]
                {
                    { new Guid("bfde935e-abe4-4d64-9c36-2cfb172fae99"), new Guid("7736d6df-d93d-42c8-82c3-639bfd7b326f"), "Horsham" },
                    { new Guid("c9ab9a01-b18f-4fbb-8acd-27359fd52c0d"), new Guid("7736d6df-d93d-42c8-82c3-639bfd7b326f"), "Brighton" },
                    { new Guid("cc53d272-23e7-436d-b5a5-c3a235cdb2fd"), new Guid("04d82d36-3c9a-4b57-94f0-509574eb1523"), "Bangor" },
                    { new Guid("e961b53c-e82b-453e-b814-ecddc031e953"), new Guid("04d82d36-3c9a-4b57-94f0-509574eb1523"), "Cardiff" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationName",
                table: "Locations",
                column: "LocationName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("0e817f5c-e063-4d2a-aca5-0e40b52dd0ce"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("6cc76f4a-5c6d-4f25-b898-0ffeaec0af1f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("7d45913f-2062-41e6-8da5-2d9f3b259552"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("c5b96f86-2305-4a90-b3cf-cd8300c28017"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("cd5aa765-ace1-4cf0-bd8d-141eca83a8e1"));

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "SiteId",
                keyValue: new Guid("bfde935e-abe4-4d64-9c36-2cfb172fae99"));

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "SiteId",
                keyValue: new Guid("c9ab9a01-b18f-4fbb-8acd-27359fd52c0d"));

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "SiteId",
                keyValue: new Guid("cc53d272-23e7-436d-b5a5-c3a235cdb2fd"));

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "SiteId",
                keyValue: new Guid("e961b53c-e82b-453e-b814-ecddc031e953"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("04d82d36-3c9a-4b57-94f0-509574eb1523"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("7736d6df-d93d-42c8-82c3-639bfd7b326f"));

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
        }
    }
}
