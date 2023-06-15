namespace Membership.Blazor.WebApiGateway;

public class UserWebApiGateway : IUserWebApiGateway
{
    readonly HttpClient Client;
    readonly UserEnpointOptions Options;

    public UserWebApiGateway(IHttpClientFactory factory, IOptions<UserEnpointOptions> options)
    {
        Options = options.Value;
        Client = factory.CreateClient(nameof(IUserWebApiGateway));
        Client.BaseAddress = new Uri(Options.WebApiBaseAddrerss);
    }

    public async Task<UserTokensDto> LoginAsync(LocalUserCredentialsDto userCredentials) 
    {
        HttpResponseMessage response = await Client.PostAsJsonAsync(Options.Login, userCredentials);
        return await response.Content.ReadFromJsonAsync<UserTokensDto>();
    }

    public async Task LogoutAsync(string refreshToken)
    {
        await Client.PostAsJsonAsync(Options.Logout, refreshToken);
    }

    public async Task<UserTokensDto> RefreshTokenAsync(UserTokensDto userTokens)
    {
        HttpResponseMessage response = await Client.PostAsJsonAsync(Options.RefreshToken, userTokens);
        return await response.Content.ReadFromJsonAsync<UserTokensDto>();
    }

    public async Task RegisterUserAsync(LocalUserForRegistrationDto userData)
    {
        await Client.PostAsJsonAsync(Options.Register, userData);
    }
}
