namespace Membership.Blazor.UI.AuthenticationStateProviders;
internal class JWTAuthenticationStateProvider : AuthenticationStateProvider, IAuthenticationStateProvider
{
    const string SessionKey = "ast";
    readonly IJSRuntime JSRuntime;
    readonly IUserWebApiGateway UserWebApiGateway;

    public JWTAuthenticationStateProvider(IJSRuntime jSRuntime, IUserWebApiGateway userWebApiGateway)
    {
        JSRuntime = jSRuntime;
        UserWebApiGateway = userWebApiGateway;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsIdentity identity = new ClaimsIdentity();
        UserTokensDto storedTokens = await GetUserTokenAsync();
        if(storedTokens != default)
        {
            JwtSecurityTokenHandler hander = new JwtSecurityTokenHandler();
            JwtSecurityToken token = hander.ReadJwtToken(storedTokens.Access_Token);
            identity = new ClaimsIdentity(token.Claims, nameof(JWTAuthenticationStateProvider));
        }
        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    public async Task LoginAsync(UserTokensDto userTokens)
    {
        string state = JsonSerializer.Serialize(userTokens);
        await JSRuntime.InvokeVoidAsync("sessionStorage.setItem", SessionKey, state);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task LogoutAsync()
    {
        await JSRuntime.InvokeVoidAsync("sessionStorage.removeItem", SessionKey);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async Task<UserTokensDto> GetUserTokenAsync()
    {
        string state = await JSRuntime.InvokeAsync<string>("sessionStorage.getItem", SessionKey);
        UserTokensDto storedTokens = default;
        if(!string.IsNullOrEmpty(state))
        {
            storedTokens = JsonSerializer.Deserialize<UserTokensDto>(state);
            
            JwtSecurityTokenHandler hander = new JwtSecurityTokenHandler();
            JwtSecurityToken token = hander.ReadJwtToken(storedTokens.Access_Token);
            if(token.ValidTo <= DateTime.UtcNow) 
            {
                try
                {
                    UserTokensDto newTokens = await UserWebApiGateway.RefreshTokenAsync(storedTokens);
                    await LoginAsync(newTokens);
                    storedTokens = newTokens;
                    await Console.Out.WriteLineAsync("Access token actualizado.");
                }
                catch(Exception ex)
                {    
                    await Console.Out.WriteLineAsync($"Access token no actualizado. {ex.Message}");
                    storedTokens = default;
                    await LogoutAsync();
                }
            }
            
        }
        return storedTokens;
    }
}
