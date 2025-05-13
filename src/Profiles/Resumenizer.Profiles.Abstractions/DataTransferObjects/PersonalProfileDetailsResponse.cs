namespace Resumenizer.Profiles.Abstractions.DataTransferObjects;

public record PersonalProfileDetailsResponse(
    Guid Id,
    string DisplayName,
    string FirstName,
    string LastName,
    string EmailAddress,
    string? PhoneNumber,
    DateOnly DateOfBirth);