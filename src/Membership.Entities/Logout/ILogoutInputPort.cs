namespace Membership.Entities.Logout;
public interface ILogoutInputPort
{
    ValueTask LogoutAsync(string refreshToken);
}
