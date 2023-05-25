namespace Membership.Entities.Login;
public interface ILoginController
{
    Task<UserTokensDto> LoginAsync(LocalUserCredentialsDto userCredentials);
}

