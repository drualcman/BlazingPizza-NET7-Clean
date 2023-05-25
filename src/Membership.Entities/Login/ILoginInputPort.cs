namespace Membership.Entities.Login;
public interface ILoginInputPort
{
    Task LoginAsync(LocalUserCredentialsDto userCredentials);
}
