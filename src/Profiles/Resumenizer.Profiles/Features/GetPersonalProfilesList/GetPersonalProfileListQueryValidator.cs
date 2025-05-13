using FluentValidation;

namespace Resumenizer.Profiles.Features.GetPersonalProfilesList;

public class GetPersonalProfilesListQueryValidator : AbstractValidator<GetPersonalProfilesListQuery>
{
    public GetPersonalProfilesListQueryValidator()
    {
        RuleFor(fld => fld.Name)
            .Matches("^[^a-zA-Z0-9À-ž\\s]*$")
            .WithMessage("Special characters are not allowed in the search string for names of personal profiles");

        RuleFor(fld => fld.EmailAddress)
            .Matches("^[^a-zA-Z0-9À-ž\\s@]*$")
            .WithMessage("Special characters are not allowed in the search string for email addresses of personal profiles");
    }
}