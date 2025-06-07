using Microsoft.EntityFrameworkCore;
using SafetySystems.Common.EFDataMigrationService;
using SafetySystems.LoneWorkerCheckin.Infrastructure.EntityFramework;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

try
{
    var loneWorkerCheckinConnectionString = builder.Configuration.GetConnectionString("loneworkercheckin-db");
    builder.Services.AddDbContextFactory<ApplicationDbContext>(dbContext => dbContext.UseSqlServer(loneWorkerCheckinConnectionString));
    builder.EnrichSqlServerDbContext<ApplicationDbContext>();

    //https://github.com/dotnet/efcore/issues/28123

    Console.WriteLine(loneWorkerCheckinConnectionString);

    var safetyAuditConnectionString = builder.Configuration.GetConnectionString("safetyaudit-db");
    builder.Services.AddDbContextFactory<ApplicationDbContext>(dbContext => dbContext.UseSqlServer(loneWorkerCheckinConnectionString));

    Console.WriteLine(safetyAuditConnectionString);
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

var host = builder.Build();
host.Run();


// var connectionString = builder.Configuration.GetConnectionString("DbName");
// builder.Services.AddDbContextFactory<DbContext>(dbContext => dbContext.UseNpgsql(connectionString));
// builder.EnrichNpgsqlDbContext<DbContext>(c => c.DisableTracing = true);
