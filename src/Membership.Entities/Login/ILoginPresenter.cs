using Membership.Entities.Dtos;

namespace Membership.Entities.Login;
public interface ILoginPresenter
{
    UserTokensDto UserTokens { get; }
    Task HandleUserDataAsync(UserDto userData);
}
