using Microsoft.Extensions.Logging;
using Resumenizer.Core.Abstractions.DataTransferObjects;
using Resumenizer.Core.Features;
using Resumenizer.Profiles.Abstractions.DataTransferObjects;
using Resumenizer.Profiles.Abstractions.Mappings;
using Resumenizer.Profiles.Abstractions.Repositories;
using Resumenizer.Profiles.DomainModels;

namespace Resumenizer.Profiles.Features.CreatePersonalProfile;

public class CreatePersonalProfileHandler(
    IPersonalProfilesRepository repository,
    ILogger<CreatePersonalProfileHandler> logger) : ICommandHandler<CreatePersonalProfileCommand, ResumenizerResponse<PersonalProfileDetailsResponse>>
{

    public async ValueTask<ResumenizerResponse<PersonalProfileDetailsResponse>> HandleAsync(
        CreatePersonalProfileCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating personal profile");
        var personalProfile = PersonalProfile.FromCreateCommand(command);

        if (await repository.Save(personalProfile, cancellationToken))
        {
            logger.LogInformation("Personal profile created");
            return ResumenizerResponse<PersonalProfileDetailsResponse>.Success(personalProfile.ToDetailsResponse());
        }

        logger.LogError("Failed to create personal profile");
        return ResumenizerResponse<PersonalProfileDetailsResponse>.Failure("Failed to create new personal profile");
    }
}