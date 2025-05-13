using FluentValidation;
using Microsoft.Extensions.Logging;
using Resumenizer.Core.Abstractions.Cqrs;
using Resumenizer.Core.Abstractions.DataTransferObjects;
using Resumenizer.Profiles.Abstractions.Repositories;

namespace Resumenizer.Profiles.Features.GetPersonalProfilesList;

public class GetPersonalProfilesListHandler(
    IPersonalProfilesRepository personalProfileRepository,
    AbstractValidator<GetPersonalProfilesListQuery> validator,
    ILogger<GetPersonalProfilesListHandler> logger)
    : IQueryHandler<GetPersonalProfilesListQuery, ResumenizerListResponse<GetPersonalProfilesListItemResponse>>
{

    public async ValueTask<ResumenizerListResponse<GetPersonalProfilesListItemResponse>> HandleAsync(
        GetPersonalProfilesListQuery query, CancellationToken cancellationToken)
    {
        // Validate user input to make sure the query is valid
        var validationResult = await validator.ValidateAsync(query, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errorMessage = string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage));
            logger.LogWarning("Validation failed for GetPersonalProfilesListQuery: {ErrorMessage}", errorMessage);
            return ResumenizerListResponse<GetPersonalProfilesListItemResponse>.Failure(errorMessage);
        }

        // Execute the query to get the list of personal profiles
        var queryResult = await personalProfileRepository.ListFind(query.Name, query.EmailAddress, cancellationToken);
        var responseList = queryResult.Select(GetPersonalProfilesListItemResponse.FromDomainModel).ToList();
        return ResumenizerListResponse<GetPersonalProfilesListItemResponse>.Success(responseList);
    }
}