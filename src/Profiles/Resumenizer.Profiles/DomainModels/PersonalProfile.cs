using HexMaster.DomainDrivenDesign;
using HexMaster.DomainDrivenDesign.ChangeTracking;
using Resumenizer.Profiles.Abstractions.DomainModels;
using Resumenizer.Profiles.Features.CreatePersonalProfile;

namespace Resumenizer.Profiles.DomainModels;

public sealed class PersonalProfile : DomainModel<Guid>, IPersonalProfile
{
    public string DisplayName { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public DateOnly DateOfBirth { get; private set; }

    public void SetDisplayName(string value)
    {
        if (!Equals(value, DisplayName))
        {
            DisplayName = value;
            SetState(TrackingState.Modified);
        }
    }

    public void SetFirstName(string value)
    {
        if (!Equals(value, FirstName))
        {
            FirstName = value;
            SetState(TrackingState.Modified);
        }
    }

    public void SetLastName(string value)
    {
        if (!Equals(value, LastName))
        {
            LastName = value;
            SetState(TrackingState.Modified);
        }
    }

    public void SetEmail(string value)
    {
        throw new NotImplementedException();
    }

    public void SetPhoneNumber(string? value)
    {
        throw new NotImplementedException();
    }

    public void SetDateOfBirth(DateOnly value)
    {
        throw new NotImplementedException();
    }

    public PersonalProfile(
        Guid id,
        string displayName,
        string firstName,
        string lastName,
        string email,
        string? phoneNumber,
        DateOnly dateOfBirth
        ) : base(id)
    {
        DisplayName = displayName;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
    }

    public PersonalProfile(
        string firstName,
        string lastName,
        string email,
        string? phoneNumber,
        DateOnly dateOfBirth) : base(Guid.NewGuid(), TrackingState.New)
    {
        DisplayName =  $"{firstName} {lastName}";
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
    }

    public static PersonalProfile FromCreateCommand(CreatePersonalProfileCommand command)
    {
        var firstName = command.FirstName;
        var lastName = command.LastName;
        var emailAddress = command.EmailAddress;
        var phoneNumber = command.PhoneNumber;
        var dateOfBirth = command.DateOfBirth;
        return new PersonalProfile(
            firstName,
            lastName,
            emailAddress,
            phoneNumber,
            dateOfBirth);
    }


}