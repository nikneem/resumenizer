using Resumenizer.Profiles.Abstractions.DataTransferObjects;
using Resumenizer.Profiles.Abstractions.DomainModels;

namespace Resumenizer.Profiles.Abstractions.Mappings;

public static class PersonalProfileMapper
{

    public static PersonalProfileDetailsResponse ToDetailsResponse(this IPersonalProfile profile)
    {
        return new PersonalProfileDetailsResponse(
            profile.Id,
            profile.DisplayName,
            profile.FirstName,
            profile.LastName,
            profile.Email,
            profile.PhoneNumber,
            profile.DateOfBirth);

    }

}