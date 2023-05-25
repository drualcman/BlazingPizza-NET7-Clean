namespace Membership.Shared.Entities;
public record struct ExternalUserForRegistrationDto(string Provider, string USerID, string Email, string FirstName, string LastName);
