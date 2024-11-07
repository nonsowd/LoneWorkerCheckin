var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddSqlServer("loneworkercheckin-sqlserver")
    .WithLifetime(ContainerLifetime.Persistent)
    .AddDatabase("loneworkercheckin-db", "loneworkercheckin");

var loneworkercheckinserviceapi = builder.AddProject<Projects.LoneWorkerCheckin_Api>("loneworkercheckin-api")
    .WithReference(db).WaitFor(db);

builder.AddProject<Projects.LoneWorkerCheckin_Blazor>("loneworkercheckin-blazor")
    .WithReference(loneworkercheckinserviceapi).WaitFor(loneworkercheckinserviceapi);

builder.Build().Run();
