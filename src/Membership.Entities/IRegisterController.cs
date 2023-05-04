namespace Membership.Entities;
public interface IRegisterController
{
    Task RegisterAsync(UserForRegistrationDto userData);
}
