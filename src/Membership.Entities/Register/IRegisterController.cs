namespace Membership.Entities.Register;
public interface IRegisterController
{
    Task RegisterAsync(LocalUserForRegistrationDto userData);
}
