namespace Membership.Entities;
public interface IRegisterInputPort
{
    Task RegisterAsync(UserForRegistrationDto userData);
}
