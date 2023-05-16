namespace Membership.Controllers;
internal class RefreshTokenController : IRefreshTokenController
{
    readonly IRefreshTokenInputPort InputPort;
    readonly IRefreshTokenPresenter Presenter;

    public RefreshTokenController(IRefreshTokenInputPort inputPort, IRefreshTokenPresenter presenter)
    {
        InputPort = inputPort;
        Presenter = presenter;
    }

    public async ValueTask<UserTokensDto> RefreshTokenAsync(UserTokensDto userTokensDto) 
    {
        await InputPort.RefreshTokenAsync(userTokensDto);
        return Presenter.UserTokens;
    }
}
