var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Resumenizer_Profiles_Api>("resumenizer-profiles-api");

builder.AddProject<Projects.Resumenizer_Skills_Api>("resumenizer-skills-api");

builder.Build().Run();
