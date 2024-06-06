var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.LoneWorkerCheckin_Api>("loneworkercheckin-api");

builder.Build().Run();
