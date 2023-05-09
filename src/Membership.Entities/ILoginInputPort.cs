namespace Membership.Entities;
public interface ILoginInputPort
{
    Task LoginAsync(UserCredentialsDto userCredentials);
}
