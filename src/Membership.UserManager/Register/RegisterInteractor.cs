namespace Membership.UserManager.Register;
public class RegisterInteractor : IRegisterInputPort
{
    readonly IUserManagerService UserManagerService;

    public RegisterInteractor(IUserManagerService userManagerService) => UserManagerService = userManagerService;

    public async Task RegisterAsync(LocalUserForRegistrationDto userData)
    {
        await UserManagerService.ThrowIfUnableToResisterAsync(
            new UserForRegistrationDto(userData.Email, userData.Email, userData.Password, userData.FirstName, userData.Password));
    }
}
