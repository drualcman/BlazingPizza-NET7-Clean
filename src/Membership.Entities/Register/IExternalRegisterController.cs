namespace Membership.Entities.Register;
public interface IExternalRegisterController
{     
    Task RegisterAsync(ExternalUserForRegistrationDto userData);
}
