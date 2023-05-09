namespace Membership.Entities;
public interface ILoginPresenter
{
    string Token { get; }
    Task HandleUserDataAsync(UserDto userData);
}
