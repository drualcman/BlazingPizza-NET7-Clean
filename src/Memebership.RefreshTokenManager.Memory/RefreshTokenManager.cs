namespace Memebership.RefreshTokenManager.Memory;
internal class RefreshTokenManager : IRefreshTokenManager
{
    readonly ConcurrentDictionary<string, Token> Tokens = new();
    readonly JwtConfigurationOptions Options;

    public RefreshTokenManager(IOptions<JwtConfigurationOptions> options) => Options = options.Value;

    public async Task ThrowIfNotCanGetNewTokenAsync(string refreshToken, string accessToken)
    {
        if (Tokens.TryGetValue(refreshToken, out Token token)) 
        {
            await DeleteTokenAsync(refreshToken);
            if(token.AccessToken != accessToken)
                throw new RefreshTokenCompromisedException();
            if (token.ExpiresAt < DateTime.UtcNow)
                throw new RefreshTokenExpiredException();
        }
        else
            throw new RefreshTokenNotFoundException();
    }

    public Task<string> GetNewTokenAsync(string accessToken) 
    {
        string refreshToken = GenerateToken();        
        Token token = GetToken(accessToken);
        if(!Tokens.TryAdd(refreshToken, token)) refreshToken = null;
        return Task.FromResult(refreshToken);
    }

    private string GenerateToken() 
    {
        byte[] buffer = new byte[75];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(buffer);
        return Convert.ToBase64String(buffer);
    }

    private Token GetToken(string accessToken) =>
        new Token
        {
            AccessToken = accessToken,
            ExpiresAt = DateTime.UtcNow.AddMinutes(Options.RefreshTokenExpireInMinutes)
        };

    public Task DeleteTokenAsync(string refreshToken) 
    {
        Tokens.TryRemove(refreshToken, out _);    //con el _ ignora el oout
        return Task.CompletedTask;
    }
}
