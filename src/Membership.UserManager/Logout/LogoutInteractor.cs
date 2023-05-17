namespace Membership.UserManager.Logout;
internal class LogoutInteractor : ILogoutInputPort
{
    readonly IRefreshTokenManager Manager;

    public LogoutInteractor(IRefreshTokenManager manager) => Manager = manager;

    public async ValueTask LogoutAsync(string refreshToken) 
    {
        await Manager.DeleteTokenAsync(refreshToken);
    }
}
