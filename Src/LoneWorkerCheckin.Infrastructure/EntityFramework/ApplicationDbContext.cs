using LoneWorkerCheckin.Domain;
using LoneWorkerCheckin.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;


namespace LoneWorkerCheckin.Infrastructure.EntityFramework;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    public string ConnectionString => Database.GetDbConnection().ConnectionString;

    public async Task EnsureDatabaseIsSetupAsync()
    {
        await Database.MigrateAsync();
    }

    public DbSet<RegionEntity> Regions { get; set; } = null!;
    public DbSet<SiteEntity> Sites { get; set; } = null!;
    public DbSet<LocationEntity> Locations { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var regionSeedData = GetRegionSeedData();

        OnModelRegionCreating(modelBuilder, regionSeedData);

        OnModelSiteCreating(modelBuilder, regionSeedData);

        OnModelLocationCreating(modelBuilder);

    }

    private void OnModelRegionCreating(ModelBuilder modelBuilder, List<RegionEntity> regionSeedData)
    {
        modelBuilder.Entity<RegionEntity>().ToTable("Regions");
        modelBuilder.Entity<RegionEntity>().HasKey(x => x.RegionId);

        modelBuilder.Entity<RegionEntity>().Property(x => x.RegionName)
            .IsRequired().IsUnicode().HasMaxLength(RegionEntity.RegionNameMaxLenght);

        modelBuilder.Entity<RegionEntity>().HasIndex(x => x.RegionName).IsUnique();

        modelBuilder.Entity<RegionEntity>().HasData(regionSeedData);

    }

    private void OnModelSiteCreating(ModelBuilder modelBuilder, List<RegionEntity> regionSeedData)
    {
        modelBuilder.Entity<SiteEntity>().ToTable("Sites");
        modelBuilder.Entity<SiteEntity>().HasKey(x => x.SiteId);

        modelBuilder.Entity<SiteEntity>().HasOne(r => r.Region).WithMany().OnDelete(DeleteBehavior.NoAction).HasForeignKey(x => x.RegionId);

        modelBuilder.Entity<SiteEntity>().Property(x => x.SiteName)
            .IsRequired().IsUnicode().HasMaxLength(SiteEntity.SiteNameMaxLenght);

        modelBuilder.Entity<SiteEntity>().HasIndex(x => x.SiteName).IsUnique();

        var siteSeedData = GetSiteSeedData(regionSeedData);
        modelBuilder.Entity<SiteEntity>().HasData(siteSeedData);
    }

    private void OnModelLocationCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LocationEntity>().ToTable("Locations");
        modelBuilder.Entity<LocationEntity>().HasKey(x => x.LocationId);

        modelBuilder.Entity<LocationEntity>().Property(x => x.LocationName)
            .IsRequired().IsUnicode().HasMaxLength(LocationEntity.LocationNameMaxLenght);

        modelBuilder.Entity<LocationEntity>().HasIndex(x => x.LocationName).IsUnique();

        var locationSeedData = GetLocationSeedData();
        modelBuilder.Entity<LocationEntity>().HasData(locationSeedData);
    }

    private List<RegionEntity> GetRegionSeedData()
        => new List<RegionEntity>()
        {
            new RegionEntity() { RegionId = Guid.NewGuid(), RegionName = Region.Names.SouthEast },
            new RegionEntity() { RegionId = Guid.NewGuid(), RegionName = Region.Names.SouthWest },
            new RegionEntity() { RegionId = Guid.NewGuid(), RegionName = Region.Names.Southern },
            new RegionEntity() { RegionId = Guid.NewGuid(), RegionName = Region.Names.Northern },
            new RegionEntity() { RegionId = Guid.NewGuid(), RegionName = Region.Names.Scotland},
            new RegionEntity() { RegionId = Guid.NewGuid(), RegionName = Region.Names.Wales},
            new RegionEntity() { RegionId = Guid.NewGuid(), RegionName = Region.Names.MiddleEngland }
        };

    private List<SiteEntity> GetSiteSeedData(List<RegionEntity> regionSeedData)
    {
        var southeastid = regionSeedData.Single(x => x.RegionName == Region.Names.SouthEast).RegionId;
        var walesid = regionSeedData.Single(x => x.RegionName == Region.Names.Wales).RegionId;

        return new List<SiteEntity>()
        {
            new SiteEntity() { SiteId = Guid.NewGuid(), RegionId = southeastid, SiteName = "Horsham" },
            new SiteEntity() { SiteId = Guid.NewGuid(), RegionId = southeastid, SiteName = "Brighton" },
            new SiteEntity() { SiteId = Guid.NewGuid(), RegionId = walesid, SiteName = "Cardiff" },
            new SiteEntity() { SiteId = Guid.NewGuid(), RegionId = walesid, SiteName = "Bangor" }
        };
    }

    private List<LocationEntity> GetLocationSeedData()
        => new List<LocationEntity>()
        {
            new LocationEntity() { LocationId = Guid.NewGuid(), LocationName = "Kitchen" },
            new LocationEntity() { LocationId = Guid.NewGuid(), LocationName = "Dinning room" },
            new LocationEntity() { LocationId = Guid.NewGuid(), LocationName = "Reception" }
        };
}
