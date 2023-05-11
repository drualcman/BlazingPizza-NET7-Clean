namespace Membership.Entities; 
public interface ILoginController 
{
    Task<UserTokensDto> LoginAsync(UserCredentialsDto userCredentials);
}

