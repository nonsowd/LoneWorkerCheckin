var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.LoneWorkerCheckin_Api>("loneworkercheckin-api");

builder.AddProject<Projects.LoneWorkerCheckin_MVC>("loneworkercheckin-mvc");

builder.Build().Run();
