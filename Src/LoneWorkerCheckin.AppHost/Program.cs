var builder = DistributedApplication.CreateBuilder(args);

var loneworkercheckinserviceapi = builder.AddProject<Projects.LoneWorkerCheckin_Api>("loneworkercheckin-api");

builder.AddProject<Projects.LoneWorkerCheckin_MVC>("loneworkercheckin-mvc")
    .WithReference(loneworkercheckinserviceapi);

builder.Build().Run();
