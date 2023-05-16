namespace Membership.Entities.Login;
public interface ILoginInputPort
{
    Task LoginAsync(UserCredentialsDto userCredentials);
}
