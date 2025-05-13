using System.Reflection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Resumenizer.Core.Abstractions.Cqrs;
using Resumenizer.Core.Features;
using Resumenizer.Profiles.Abstractions.Repositories;
using FluentValidation;
using Resumenizer.Profiles.Features.GetPersonalProfilesList;

namespace Resumenizer.Profiles.ExtensionMethods;

public static class HostApplicationBuilderExtensions
{


    public static TBuilder AddPersonalProfileServices<TBuilder>(this TBuilder builder) where TBuilder : IHostApplicationBuilder
    {
        //builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Services
            .AddSingleton<AbstractValidator<GetPersonalProfilesListQuery>, GetPersonalProfilesListQueryValidator>();

        builder.Services.Scan(scan => scan
            .FromAssemblyOf<ResumenizerApplicationAssemblyLocator>()
            // Command handlers
            .AddClasses(classes => classes.AssignableTo<ICommandHandler>())
            .AsSelfWithInterfaces()
            .WithScopedLifetime()
            .AddClasses(classes => classes.AssignableTo<IQueryHandler>())
            .AsSelfWithInterfaces()
            .WithScopedLifetime());

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