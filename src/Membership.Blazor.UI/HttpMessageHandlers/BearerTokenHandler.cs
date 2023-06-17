namespace Membership.Blazor.UI.HttpMessageHandlers;
internal class BearerTokenHandler : DelegatingHandler, IBearerTokenHander
{
    readonly IAuthenticationStateProvider AuthenticationStateProvider;

    public BearerTokenHandler(IAuthenticationStateProvider authenticationStateProvider) => AuthenticationStateProvider = authenticationStateProvider;

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) 
    {
        UserTokensDto storedTokens = await AuthenticationStateProvider.GetUserTokenAsync();
        if(storedTokens != default)
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", storedTokens.Access_Token);
        }
        return await base.SendAsync(request, cancellationToken);
    }
}
