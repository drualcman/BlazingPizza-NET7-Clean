namespace Membership.Entities.Logout;
public interface ILogoutController
{
    ValueTask LogoutAsync(string refreshToken);
}
