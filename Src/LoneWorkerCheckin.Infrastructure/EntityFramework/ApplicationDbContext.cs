using LoneWorkerCheckin.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LoneWorkerCheckin.Infrastructure.EntityFramework;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {

    }

    public string ConnectionString => Database.GetDbConnection().ConnectionString;
    public void EnsureDatabaseIsCreated() => Database.EnsureCreated();
    public void Migrate() => Database.Migrate();

    public DbSet<RegionEntity> Regions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegionEntity>().ToTable("Regions");
        modelBuilder.Entity<RegionEntity>().HasKey(x => x.RegionId);

        modelBuilder.Entity<RegionEntity>().Property(x => x.RegionName)
            .IsRequired().IsUnicode().HasMaxLength(RegionEntity.RegionNameMaxLenght);

        var regionSeedData = new List<RegionEntity>()
        {
            new RegionEntity() {RegionId = Guid.NewGuid(), RegionName = "South East"},
            new RegionEntity() {RegionId = Guid.NewGuid(), RegionName = "South West"},
            new RegionEntity() {RegionId = Guid.NewGuid(), RegionName = "Southern"},
            new RegionEntity() {RegionId = Guid.NewGuid(), RegionName = "Northern"},
            new RegionEntity() {RegionId = Guid.NewGuid(), RegionName = "Scotland"},
            new RegionEntity() {RegionId = Guid.NewGuid(), RegionName = "Wales"},
            new RegionEntity() {RegionId = Guid.NewGuid(), RegionName = "Middle England"}
        };
        modelBuilder.Entity<RegionEntity>().HasData(regionSeedData);
    }
}

