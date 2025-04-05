using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SafetySystems.LoneWorkerCheckin.Infrastructure.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class AddedCheckins : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("2ac4032b-240f-4029-9d64-d20848c8d694"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("6d55a9ed-e128-4366-97d0-eddcb6fa7c58"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("774e9499-fb15-4995-8dc8-43610a5f5b53"));

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

            migrationBuilder.CreateTable(
                name: "Checkins",
                columns: table => new
                {
                    CheckinId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkins", x => x.CheckinId);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "LocationName" },
                values: new object[,]
                {
                    { new Guid("1a86e167-a21c-4467-9beb-1e63b08d371f"), "Kitchen" },
                    { new Guid("27efc204-445e-4321-a845-8a72d7f84f71"), "Reception" },
                    { new Guid("8aec57a1-4918-4772-aea5-1e0fddd68c6d"), "Dinning room" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "RegionId", "RegionName" },
                values: new object[,]
                {
                    { new Guid("030f5eaf-d8c1-4489-b871-737ee8e06ed1"), "Wales" },
                    { new Guid("1cc438b5-ffae-4fc2-8045-be779200b829"), "Southern" },
                    { new Guid("506ccb78-dac0-4e18-96a1-d014b61c58da"), "South West" },
                    { new Guid("5ba01a1e-51f4-49b0-b4f7-512ed3746433"), "Middle England" },
                    { new Guid("6b7331db-983b-4724-8a24-12951aab38b6"), "South East" },
                    { new Guid("ac2fa921-b9e5-4c44-9795-f60ed999e0c4"), "Northern" },
                    { new Guid("fe07a80f-b774-4b15-b496-a8db27a4d5ef"), "Scotland" }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "SiteId", "RegionId", "SiteName" },
                values: new object[,]
                {
                    { new Guid("4583d6d5-56ea-4701-8188-2cb29af75ab1"), new Guid("030f5eaf-d8c1-4489-b871-737ee8e06ed1"), "Cardiff" },
                    { new Guid("81b1a919-6e37-4c4f-af7c-76cc4be85811"), new Guid("030f5eaf-d8c1-4489-b871-737ee8e06ed1"), "Bangor" },
                    { new Guid("e915faba-37a8-4dc9-8d03-1b9196edc227"), new Guid("6b7331db-983b-4724-8a24-12951aab38b6"), "Horsham" },
                    { new Guid("ef227e96-c100-42bc-af5b-b08e1d215d64"), new Guid("6b7331db-983b-4724-8a24-12951aab38b6"), "Brighton" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkins");

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("1a86e167-a21c-4467-9beb-1e63b08d371f"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("27efc204-445e-4321-a845-8a72d7f84f71"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: new Guid("8aec57a1-4918-4772-aea5-1e0fddd68c6d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("1cc438b5-ffae-4fc2-8045-be779200b829"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("506ccb78-dac0-4e18-96a1-d014b61c58da"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("5ba01a1e-51f4-49b0-b4f7-512ed3746433"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("ac2fa921-b9e5-4c44-9795-f60ed999e0c4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("fe07a80f-b774-4b15-b496-a8db27a4d5ef"));

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "SiteId",
                keyValue: new Guid("4583d6d5-56ea-4701-8188-2cb29af75ab1"));

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "SiteId",
                keyValue: new Guid("81b1a919-6e37-4c4f-af7c-76cc4be85811"));

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "SiteId",
                keyValue: new Guid("e915faba-37a8-4dc9-8d03-1b9196edc227"));

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "SiteId",
                keyValue: new Guid("ef227e96-c100-42bc-af5b-b08e1d215d64"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("030f5eaf-d8c1-4489-b871-737ee8e06ed1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "RegionId",
                keyValue: new Guid("6b7331db-983b-4724-8a24-12951aab38b6"));

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
        }
    }
}
