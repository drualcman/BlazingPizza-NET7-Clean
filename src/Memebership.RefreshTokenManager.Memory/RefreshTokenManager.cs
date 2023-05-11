using Microsoft.Extensions.Options;
using System.Collections.Concurrent;
using System.Security.Cryptography;

namespace Memebership.RefreshTokenManager.Memory;
internal class RefreshTokenManager : IRefreshTokenManager
{
    readonly ConcurrentDictionary<string, Token> Tokens = new();
    readonly JwtConfigurationOptions Options;

    public RefreshTokenManager(IOptions<JwtConfigurationOptions> options) => Options = options.Value;

    public Task<string> GetNewTokenAsync(string userName) 
    {
        string refreshToken = GenerateToken();        
        Token token = GetToken(userName);
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

    private Token GetToken(string userName) =>
        new Token
        {
            UserName = userName,
            ExpiresAt = DateTime.UtcNow.AddMinutes(Options.RefreshTokenExpireInMinutes)
        };

    public async Task<string> RotateTokenAsync(string userName, string refreshToken)
    {
        string result = null;
        if(Tokens.TryGetValue(refreshToken, out Token token))
        {
            if(token.ExpiresAt > DateTime.UtcNow)
            {
                if(await DeleteTokenAsync(userName, refreshToken))
                    result = await GetNewTokenAsync(userName);
            }
        }
        return result;
    }

    public Task<bool> DeleteTokenAsync(string userName, string refreshToken) 
    {
        bool result = false;
        if(Tokens.TryGetValue(refreshToken, out Token token))
        {
            if(token.UserName == userName) 
            {
                result = Tokens.TryRemove(refreshToken, out token);
                //result = Tokens.TryRemove(refreshToken, out _);    //con el _ ignora el oout
            }
        }
        return Task.FromResult(result);
    }
}
