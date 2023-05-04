namespace Membership.UserManager.Register;
public class RegisterInteractor : IRegisterInputPort
{
    readonly IUserManagerService UserManagerService;

    public RegisterInteractor(IUserManagerService userManagerService) => UserManagerService = userManagerService;

    public async Task RegisterAsync(UserForRegistrationDto userData) =>
        await UserManagerService.ThrowIfUnableToResisterAsync(userData);
}
