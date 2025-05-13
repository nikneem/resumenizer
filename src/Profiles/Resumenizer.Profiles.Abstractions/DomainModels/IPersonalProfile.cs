using HexMaster.DomainDrivenDesign.Abstractions;

namespace Resumenizer.Profiles.Abstractions.DomainModels;

public interface IPersonalProfile : IDomainModel<Guid>
{
    string DisplayName { get; }
    string FirstName { get; }
    string LastName { get; }
    string Email { get; }
    string? PhoneNumber { get; }
    DateOnly DateOfBirth { get; }

    void SetDisplayName(string value);
    void SetFirstName(string value);
    void SetLastName(string value);
    void SetEmail(string value);
    void SetPhoneNumber(string? value);
    void SetDateOfBirth(DateOnly value);
    
}