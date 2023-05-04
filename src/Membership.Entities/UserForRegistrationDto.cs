namespace Membership.Entities;
public record struct UserForRegistrationDto(string Email, string Password, string FirstName, string LastName);
