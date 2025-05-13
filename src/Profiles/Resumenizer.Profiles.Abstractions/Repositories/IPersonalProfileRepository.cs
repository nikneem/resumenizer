using Resumenizer.Profiles.Abstractions.DomainModels;

namespace Resumenizer.Profiles.Abstractions.Repositories;

public interface IPersonalProfilesRepository
{
    Task<bool> Save(IPersonalProfile profile, CancellationToken cancellationToken);

    Task<List<IPersonalProfile>> ListFind(string? name, string? emailAddress, CancellationToken cancellationToken);
}