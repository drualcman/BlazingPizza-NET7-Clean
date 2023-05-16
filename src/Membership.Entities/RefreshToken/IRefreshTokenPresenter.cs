namespace Membership.Entities.RefreshToken;
public interface IRefreshTokenPresenter
{
    UserTokensDto UserTokens { get; }
    Task GenerateTokenAsync(string oldAccessToken);
}
