var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddSqlServer("loneworkercheckin-sqlserver")
    .WithHealthCheck()
    .AddDatabase("loneworkercheckin-db", "loneworkercheckin");

var loneworkercheckinserviceapi = builder.AddProject<Projects.LoneWorkerCheckin_Api>("loneworkercheckin-api")
    .WithReference(db).WaitFor(db)
    .WithHealthCheck();

builder.AddProject<Projects.LoneWorkerCheckin_Blazor>("loneworkercheckin-blazor")
    .WithReference(loneworkercheckinserviceapi).WaitFor(loneworkercheckinserviceapi)
    .WithHealthCheck();

builder.Build().Run();
