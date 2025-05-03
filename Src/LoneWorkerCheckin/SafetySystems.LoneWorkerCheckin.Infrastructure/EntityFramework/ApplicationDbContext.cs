using SafetySystems.LoneWorkerCheckin.Domain;
using SafetySystems.LoneWorkerCheckin.Infrastructure.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Reflection.Emit;
using System.Xml.Serialization;


namespace SafetySystems.LoneWorkerCheckin.Infrastructure.EntityFramework;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseAsyncSeeding(async (context, _, cancellationToken) =>
        {
            // Region seed data ...
            var regionSeedData = GetRegionSeedData();
            if(context.Set<RegionEntity>().Any() == false)
            {
                await context.Set<RegionEntity>().AddRangeAsync(regionSeedData);
            }

            // Site seed data ...
            var siteSeedData = GetSiteSeedData(regionSeedData);
            if (context.Set<SiteEntity>().Any() == false)
            {
                await context.Set<SiteEntity>().AddRangeAsync(siteSeedData);
            }
          
            // Location seed data ...
            var locationSeedData = GetLocationSeedData();
            if (context.Set<LocationEntity>().Any() == false)
            {
                await context.Set<LocationEntity>().AddRangeAsync(locationSeedData);
            }
            context.SaveChanges();
        });
    }

    public string ConnectionString => Database.GetDbConnection().ConnectionString;

    public async Task EnsureDatabaseIsSetupAsync()
    {
        await Database.MigrateAsync();
    }

    public DbSet<RegionEntity> Regions { get; set; } = null!;
    public DbSet<SiteEntity> Sites { get; set; } = null!;
    public DbSet<LocationEntity> Locations { get; set; } = null!;
    public DbSet<CheckinEntity> Checkins { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelRegionCreating(modelBuilder);
        OnModelSiteCreating(modelBuilder);
        OnModelLocationCreating(modelBuilder);
        OnModelCheckinCreating(modelBuilder);
    }

    private void OnModelRegionCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegionEntity>().ToTable("Regions");
        modelBuilder.Entity<RegionEntity>().HasKey(x => x.RegionId);

        modelBuilder.Entity<RegionEntity>().Property(x => x.RegionName)
            .IsRequired().IsUnicode().HasMaxLength(RegionEntity.RegionNameMaxLenght);

        modelBuilder.Entity<RegionEntity>().HasIndex(x => x.RegionName).IsUnique();
    }

    private void OnModelSiteCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SiteEntity>().ToTable("Sites");
        modelBuilder.Entity<SiteEntity>().HasKey(x => x.SiteId);

        modelBuilder.Entity<SiteEntity>().HasOne(r => r.Region).WithMany().OnDelete(DeleteBehavior.NoAction).HasForeignKey(x => x.RegionId);

        modelBuilder.Entity<SiteEntity>().Property(x => x.SiteName)
            .IsRequired().IsUnicode().HasMaxLength(SiteEntity.SiteNameMaxLenght);

        modelBuilder.Entity<SiteEntity>().HasIndex(x => x.SiteName).IsUnique();
    }

    private void OnModelLocationCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LocationEntity>().ToTable("Locations");
        modelBuilder.Entity<LocationEntity>().HasKey(x => x.LocationId);

        modelBuilder.Entity<LocationEntity>().Property(x => x.LocationName)
            .IsRequired().IsUnicode().HasMaxLength(LocationEntity.LocationNameMaxLenght);

        modelBuilder.Entity<LocationEntity>().HasIndex(x => x.LocationName).IsUnique();
    }

    private void OnModelCheckinCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CheckinEntity>().ToTable("Checkins");
        modelBuilder.Entity<CheckinEntity>().HasKey(x => x.CheckinId);

        // TODO: MAP foreign keys for; UserId, SiteId, LocationId

        // modelBuilder.Entity<SiteEntity>().HasOne(r => r.Region).WithMany().OnDelete(DeleteBehavior.NoAction).HasForeignKey(x => x.RegionId);

        modelBuilder.Entity<CheckinEntity>().Property(x => x.Latitude)
            .IsRequired();
        modelBuilder.Entity<CheckinEntity>().Property(x => x.Longitude)
            .IsRequired();
        modelBuilder.Entity<CheckinEntity>().Property(x => x.TimeStamp)
            .IsRequired();

        modelBuilder.Entity<SiteEntity>().HasIndex(x => x.SiteName).IsUnique();
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
