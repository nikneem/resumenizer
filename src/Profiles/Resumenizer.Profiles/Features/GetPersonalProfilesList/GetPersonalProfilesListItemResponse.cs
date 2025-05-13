using Resumenizer.Profiles.Abstractions.DomainModels;

namespace Resumenizer.Profiles.Features.GetPersonalProfilesList;

public record GetPersonalProfilesListItemResponse(
    Guid Id,
    string DisplayName,
    string FirstName,
    string LastName,
    string EmailAddress,
    string? PhoneNumber,
    DateOnly DateOfBirth)
{
    internal static GetPersonalProfilesListItemResponse FromDomainModel(IPersonalProfile domainModel)
    {
        return new GetPersonalProfilesListItemResponse(
            domainModel.Id,
            domainModel.DisplayName,
            domainModel.FirstName,
            domainModel.LastName,
            domainModel.Email,
            domainModel.PhoneNumber,
            domainModel.DateOfBirth
        );
    }
}