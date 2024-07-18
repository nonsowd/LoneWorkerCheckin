﻿// <auto-generated />
using System;
using LoneWorkerCheckin.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoneWorkerCheckin.Infrastructure.EntityFramework.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasIndex("RegionName")
                        .IsUnique();

                    b.ToTable("Regions", (string)null);

                    b.HasData(
                        new
                        {
                            RegionId = new Guid("c56db57a-e902-45bf-a56c-b38143fa80d2"),
                            RegionName = "South East"
                        },
                        new
                        {
                            RegionId = new Guid("eb1057b5-8255-43c0-9796-02bbe47c1d45"),
                            RegionName = "South West"
                        },
                        new
                        {
                            RegionId = new Guid("278ad6af-b008-403d-a25f-a249cd6e6351"),
                            RegionName = "Southern"
                        },
                        new
                        {
                            RegionId = new Guid("566c89af-b5fd-4aeb-a93c-1f942c80d33b"),
                            RegionName = "Northern"
                        },
                        new
                        {
                            RegionId = new Guid("810411d4-5f2f-46af-9400-972e50a77281"),
                            RegionName = "Scotland"
                        },
                        new
                        {
                            RegionId = new Guid("135c06f2-7caf-4fbf-bcfe-9cbbe4beb67e"),
                            RegionName = "Wales"
                        },
                        new
                        {
                            RegionId = new Guid("45d2fd15-f2c7-4eb0-adf9-87ef939d17fe"),
                            RegionName = "Middle England"
                        });
                });

            modelBuilder.Entity("LoneWorkerCheckin.Infrastructure.EntityFramework.Models.SiteEntity", b =>
                {
                    b.Property<Guid>("SiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RegionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SiteName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("SiteId");

                    b.HasIndex("RegionId");

                    b.HasIndex("SiteName")
                        .IsUnique();

                    b.ToTable("Sites", (string)null);

                    b.HasData(
                        new
                        {
                            SiteId = new Guid("b4200663-b5d1-40f2-8603-d5a2f6e2cf1a"),
                            RegionId = new Guid("c56db57a-e902-45bf-a56c-b38143fa80d2"),
                            SiteName = "Horsham"
                        },
                        new
                        {
                            SiteId = new Guid("01ff832c-6f4f-4750-9065-0539bb380505"),
                            RegionId = new Guid("c56db57a-e902-45bf-a56c-b38143fa80d2"),
                            SiteName = "Brighton"
                        },
                        new
                        {
                            SiteId = new Guid("c1870ae7-fe5a-4c9b-8c0e-fb2d874aabab"),
                            RegionId = new Guid("135c06f2-7caf-4fbf-bcfe-9cbbe4beb67e"),
                            SiteName = "Cardiff"
                        },
                        new
                        {
                            SiteId = new Guid("1be49094-cfed-4743-9d29-df49d3d924b5"),
                            RegionId = new Guid("135c06f2-7caf-4fbf-bcfe-9cbbe4beb67e"),
                            SiteName = "Bangor"
                        });
                });

            modelBuilder.Entity("LoneWorkerCheckin.Infrastructure.EntityFramework.Models.SiteEntity", b =>
                {
                    b.HasOne("LoneWorkerCheckin.Infrastructure.EntityFramework.Models.RegionEntity", "Region")
                        .WithMany()
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Region");
                });
#pragma warning restore 612, 618
        }
    }
}
