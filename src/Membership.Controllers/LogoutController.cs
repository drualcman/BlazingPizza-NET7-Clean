using Membership.Entities.Logout;

namespace Membership.Controllers;
internal class LogoutController : ILogoutController
{
    readonly ILogoutInputPort InputPort;

    public LogoutController(ILogoutInputPort inputPort) => InputPort = inputPort;

    public ValueTask LogoutAsync(string refreshToken) =>
        InputPort.LogoutAsync(refreshToken);
}
