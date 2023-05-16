namespace Membership.UserManager.RefreshToken;
internal class RefreshTokenInteractor : IRefreshTokenInputPort
{
    readonly IRefreshTokenManager Manager;
    readonly IRefreshTokenPresenter Presenter;

    public RefreshTokenInteractor(IRefreshTokenManager manager, IRefreshTokenPresenter presenter)
    {
        Manager = manager;
        Presenter = presenter;
    }

    public async Task RefreshTokenAsync(UserTokensDto userTokensDto) 
    {
        await Manager.ThrowIfNotCanGetNewTokenAsync(userTokensDto.Refresh_Token, userTokensDto.Access_Token);
        await Presenter.GenerateTokenAsync(userTokensDto.Access_Token);
    }
}
