namespace Membership.Entities; 
public interface ILoginController 
{
    Task<string> LoginAsync(UserCredentialsDto userCredentials);
}

