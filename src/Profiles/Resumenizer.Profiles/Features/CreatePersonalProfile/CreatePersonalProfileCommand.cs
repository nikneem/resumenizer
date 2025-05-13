using Resumenizer.Core.Cqrs;

namespace Resumenizer.Profiles.Features.CreatePersonalProfile;

public record CreatePersonalProfileCommand(
    string FirstName,
    string LastName,
    string EmailAddress,
    string? PhoneNumber,
    DateOnly DateOfBirth) : CommandBase;