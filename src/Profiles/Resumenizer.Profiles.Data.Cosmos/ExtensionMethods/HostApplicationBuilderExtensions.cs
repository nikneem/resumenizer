using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Resumenizer.Profiles.Abstractions.Repositories;

namespace Resumenizer.Profiles.Data.Cosmos.ExtensionMethods;

public static class HostApplicationBuilderExtensions
{


    public static TBuilder WithCosmosDb<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
    {
        builder.Services.AddScoped<IPersonalProfilesRepository, PersonalProfilesRepository>();

       // Register all command and domain event handlers
        //services.Scan(scan => scan
        //    .FromAssemblyOf<ApplicationAssemblyLocator>()
        //    // Command handlers
        //    .AddClasses(classes => classes.AssignableTo<ICommandHandler>())
        //    .AsSelfWithInterfaces()
        //    .WithScopedLifetime()
        //    // Domain event handlers
        //    .AddClasses(classes => classes.AssignableTo<IDomainEventHandler>())
        //    .AsSelfWithInterfaces()
        //    .WithScopedLifetime()
        //    // Query handlers


        return builder;
    }

}