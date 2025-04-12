var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddSqlServer("loneworkercheckin-sqlserver")
    .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("loneworkercheckin-db", "loneworkercheckin");

var loneworkercheckinserviceapi = builder.AddProject<Projects.SafetySystems_LoneWorkerCheckin_Api>("loneworkercheckin-api")
    .WithReference(db).WaitFor(db);

builder.AddProject<Projects.SafetySystems_LoneWorkerCheckin_Blazor>("loneworkercheckin-blazor")
    .WithReference(loneworkercheckinserviceapi).WaitFor(loneworkercheckinserviceapi);

var safetyauditapi = builder.AddProject<Projects.SafetySystems_SafetyAudit_Api>("safetyaudit-api");

builder.AddProject<Projects.SafetySystems_SafetyAudit_Blazor>("safetyaudit-blazor")
    .WithReference(safetyauditapi).WaitFor(safetyauditapi);

builder.Build().Run();
