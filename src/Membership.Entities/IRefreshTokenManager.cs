namespace Membership.Entities;
public interface IRefreshTokenManager
{
    Task<string> GetNewTokenAsync(string accessToken);
    Task<bool> DeleteTokenAsync(string refreshToken);
    Task<bool> CanGetNewTokenAsync(string refreshToken, string accessToken);
}
