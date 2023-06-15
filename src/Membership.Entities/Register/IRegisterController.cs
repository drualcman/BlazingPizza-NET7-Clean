namespace Membership.Entities.Register;
public interface IRegisterController
{
    Task RegisterAsync(Shared.Entities.LocalUserForRegistrationDto userData);
}
