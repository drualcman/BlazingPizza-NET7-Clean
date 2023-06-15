namespace Membership.Entities.Register;
public interface IRegisterInputPort
{
    Task RegisterAsync(Shared.Entities.LocalUserForRegistrationDto userData);
}
