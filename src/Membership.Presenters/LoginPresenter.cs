using Membership.Shared.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Membership.Presenters;
internal class LoginPresenter : ILoginPresenter
{
    readonly JwtConfigurationOptions Options;

    public LoginPresenter(IOptions<JwtConfigurationOptions> options)
    {
        Options = options.Value;
    }

    public UserTokensDto Token { get; private set; }

    public Task HandleUserDataAsync(UserDto userData) 
    {
        SigningCredentials signingCredentials = GetSigingCredentials();
        List<Claim> claims = GetClaims(userData);
        JwtSecurityToken jwtSecurityToken = GetSecutiryToken(signingCredentials, claims);
        //Token = jwtSecurityToken.ToString();
        Token = new UserTokensDto(new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken), "");
        return Task.CompletedTask;
    }

    SigningCredentials GetSigingCredentials()
    {
        byte[] key = Encoding.UTF8.GetBytes(Options.SecurityKey);
        SymmetricSecurityKey secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    List<Claim> GetClaims(UserDto userData) =>
        new List<Claim>
        {
            new Claim(ClaimTypes.Name, userData.Email),
            new Claim("FullName", $"{userData.FirstName} {userData.LastName}".Trim())
        };

    JwtSecurityToken GetSecutiryToken(SigningCredentials signingCredentials, List<Claim> claims) =>
        new JwtSecurityToken(
            issuer: Options.ValidIssuer, 
            audience:  Options.ValidAudience, 
            claims: claims, 
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(Options.ExpireInMinutes)), 
            signingCredentials: signingCredentials);
}
