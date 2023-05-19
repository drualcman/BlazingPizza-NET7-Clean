namespace Membership.Entities.Register;
public interface IRegisterInputPort
{
    Task RegisterAsync(LocalUserForRegistrationDto userData);
}
