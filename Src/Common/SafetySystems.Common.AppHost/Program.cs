var builder = DistributedApplication.CreateBuilder(args);

builder.AddKeycloak("keycloak", 8080)
    .WithDataVolume("keycloak-data")
    .WithLifetime(ContainerLifetime.Persistent);

// TODO: Switch to Postgres Efcore
var loneworkersqldb = builder.AddSqlServer("loneworkercheckin-sqlserver")
    //.WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("loneworkercheckin-db", "loneworkercheckin");

// TODO: Switch to Sql + Dapper
var safetyauditpostgresdb = builder.AddPostgres("safetyaudit-postgres")
    //.WithLifetime(ContainerLifetime.Persistent)
    .WithPgAdmin()
    .AddDatabase("safetyaudit-db", "safetyaudit");

var loneworkercheckinserviceapi = builder.AddProject<Projects.SafetySystems_LoneWorkerCheckin_Api>("loneworkercheckin-api")
    .WithReference(loneworkersqldb).WaitFor(loneworkersqldb);

builder.AddProject<Projects.SafetySystems_LoneWorkerCheckin_Blazor>("loneworkercheckin-blazor")
    .WithReference(loneworkercheckinserviceapi).WaitFor(loneworkercheckinserviceapi);

var safetyauditapi = builder.AddProject<Projects.SafetySystems_SafetyAudit_Api>("safetyaudit-api")
    .WithReference(safetyauditpostgresdb).WaitFor(safetyauditpostgresdb);

builder.AddProject<Projects.SafetySystems_SafetyAudit_Blazor>("safetyaudit-blazor")
    .WithReference(safetyauditapi).WaitFor(safetyauditapi);

builder.AddProject<Projects.SafetySystems_Common_EFDataMigrationService>("safetysystems-efdatamigrationservice")
    .WithReference(loneworkersqldb).WaitFor(loneworkersqldb)
    .WithReference(safetyauditpostgresdb).WaitFor(safetyauditpostgresdb);

await builder.Build().RunAsync();
