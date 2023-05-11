namespace Membership.Entities;
public interface ILoginPresenter
{
    UserTokensDto Token { get; }
    Task HandleUserDataAsync(UserDto userData);
}
