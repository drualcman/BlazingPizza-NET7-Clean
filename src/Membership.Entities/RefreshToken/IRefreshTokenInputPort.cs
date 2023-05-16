namespace Membership.Entities.RefreshToken;
public interface IRefreshTokenInputPort
{
    Task RefreshTokenAsync(UserTokensDto userTokensDto);
}
