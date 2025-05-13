using Resumenizer.Profiles.Abstractions.DomainModels;
using Resumenizer.Profiles.Abstractions.Repositories;
using Resumenizer.Profiles.DomainModels;

namespace Resumenizer.Profiles.Data.Cosmos
{
    public sealed class PersonalProfilesRepository : IPersonalProfilesRepository
    {
        public Task<bool> Save(IPersonalProfile profile, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public Task<List<IPersonalProfile>> ListFind(string? name, string? emailAddress, CancellationToken cancellationToken)
        {
            var list = new List<IPersonalProfile>()
            {
                new PersonalProfile(
                    Guid.NewGuid(),
                    "Henk Willemse",
                    "Henk",
                    "Willemse",
                    "h.willemse@4dotnet.nl",
                    "0612345678",
                    new DateOnly(1980, 1, 1))
                
            };

            return Task.FromResult(list);
        }
    }
}
