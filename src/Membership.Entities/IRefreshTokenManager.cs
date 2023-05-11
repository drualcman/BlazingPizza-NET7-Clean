namespace Membership.Entities;
public interface IRefreshTokenManager
{
    Task<string> GetNewTokenAsync(string userName);
    Task<string> RotateTokenAsync(string userName, string refreshToken);
    Task<bool> DeleteTokenAsync(string userName, string refreshToken);
}
