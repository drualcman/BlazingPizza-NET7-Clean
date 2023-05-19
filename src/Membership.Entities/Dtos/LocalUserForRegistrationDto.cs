namespace Membership.Entities.Dtos;
public record struct LocalUserForRegistrationDto(string Email, string Password, string FirstName, string LastName);