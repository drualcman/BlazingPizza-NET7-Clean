namespace Membership.Presenters;
internal class RefreshTokenPresenter : IRefreshTokenPresenter
{
    readonly JwtConfigurationOptions Options;
    readonly IRefreshTokenManager RefreshTokenManager;

    public RefreshTokenPresenter(IOptions<JwtConfigurationOptions> options, IRefreshTokenManager refreshTokenManager)
    {
        Options = options.Value;
        RefreshTokenManager = refreshTokenManager;
    }

    public UserTokensDto UserTokens { get; private set; }

    public async Task GenerateTokenAsync(string oldAccessToken)
    {
        List<Claim> claims = JwtHelper.GetClaimsFromToken(oldAccessToken);
        string accessToken = JwtHelper.GetAccessToken(Options, claims);
        string refreshToken = await RefreshTokenManager.GetNewTokenAsync(accessToken);
        UserTokens = new UserTokensDto(accessToken, refreshToken);
    }
}
