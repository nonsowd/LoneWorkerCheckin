var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddSqlServer("loneworkercheckin-sqlserver")
    .AddDatabase("loneworkercheckin-db", "loneworkercheckin");

var loneworkercheckinserviceapi = builder.AddProject<Projects.LoneWorkerCheckin_Api>("loneworkercheckin-api")
    .WithReference(db);

builder.AddProject<Projects.LoneWorkerCheckin_MVC>("loneworkercheckin-mvc")
    .WithReference(loneworkercheckinserviceapi);

builder.Build().Run();
