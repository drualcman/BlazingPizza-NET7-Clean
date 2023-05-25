namespace Membership.Entities.Register;
public interface IExternalRegisterInputPort
{
    Task RegisterAsync(ExternalUserForRegistrationDto userData);
}
