namespace Membership.UserManager.Login;
internal class LoginInteractor : ILoginInputPort
{
    readonly IUserManagerService UserManagerService;
    readonly ILoginPresenter Presenter;

    public LoginInteractor(IUserManagerService userManagerService, ILoginPresenter presenter)
    {
        UserManagerService = userManagerService;
        Presenter = presenter;
    }

    public async Task LoginAsync(LocalUserCredentialsDto userCredentials) 
    {
        UserDto userData = await UserManagerService.ThrowIfUnableToGetUserByCredentialsAsync(userCredentials);
        await Presenter.HandleUserDataAsync(userData);
    }
}
