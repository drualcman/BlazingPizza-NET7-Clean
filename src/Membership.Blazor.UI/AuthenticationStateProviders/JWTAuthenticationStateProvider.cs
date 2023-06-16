namespace Membership.Blazor.UI.AuthenticationStateProviders;
internal class JWTAuthenticationStateProvider : AuthenticationStateProvider, IAuthenticationStateProvider
{
    const string SessionKey = "ast";
    readonly IJSRuntime JSRuntime;

    public JWTAuthenticationStateProvider(IJSRuntime jSuntime) => JSRuntime = jSuntime;

     public override async Task<AuthenticationState> GetAuthenticationStateAsync() 
    {
        ClaimsIdentity identity = new ClaimsIdentity();
        string state = await JSRuntime.InvokeAsync<string>("sessionStorage.getItem", SessionKey);
        if (!string.IsNullOrEmpty(state))
        {
            UserTokensDto storedTokens = JsonSerializer.Deserialize<UserTokensDto>(state);
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
}
