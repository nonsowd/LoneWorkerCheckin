﻿// <auto-generated />
using System;
using LoneWorkerCheckin.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoneWorkerCheckin.Infrastructure.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240704191430_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LoneWorkerCheckin.Infrastructure.EntityFramework.Models.RegionEntity", b =>
                {
                    b.Property<Guid>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("RegionId");

                    b.ToTable("Regions", (string)null);

                    b.HasData(
                        new
                        {
                            RegionId = new Guid("0b6ddb7e-af14-4662-86c6-82b60ea2e442"),
                            RegionName = "South East"
                        },
                        new
                        {
                            RegionId = new Guid("1440eec7-5c8b-47d8-a56b-e14cd8ba721f"),
                            RegionName = "South West"
                        },
                        new
                        {
                            RegionId = new Guid("78d78dcc-9361-42d4-b00d-5b9b3ccc413e"),
                            RegionName = "Southern"
                        },
                        new
                        {
                            RegionId = new Guid("f00995d7-97f5-42ff-b4ad-a0bc58f67d2d"),
                            RegionName = "Northern"
                        },
                        new
                        {
                            RegionId = new Guid("ee11b5ba-cc38-4bae-99b4-ae91324e5178"),
                            RegionName = "Scotland"
                        },
                        new
                        {
                            RegionId = new Guid("789166b2-eb77-4c7e-8536-cf173afc9936"),
                            RegionName = "Wales"
                        },
                        new
                        {
                            RegionId = new Guid("52c20088-e5aa-4b48-8be5-6f646b4d985c"),
                            RegionName = "Middle England"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
