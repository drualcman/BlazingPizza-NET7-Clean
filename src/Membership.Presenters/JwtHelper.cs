namespace Membership.Presenters;
internal static class JwtHelper
{
    static SigningCredentials GetSigingCredentials(JwtConfigurationOptions options)
    {
        byte[] key = Encoding.UTF8.GetBytes(options.SecurityKey);
        SymmetricSecurityKey secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    public static List<Claim> GetUserClaims(UserDto userData) =>
    new List<Claim>
    {
        new Claim(ClaimTypes.Name, userData.Email),
        new Claim("FullName", $"{userData.FirstName} {userData.LastName}".Trim())
    };

    static JwtSecurityToken GetSecutiryToken(JwtConfigurationOptions options, SigningCredentials signingCredentials, List<Claim> claims) =>
        new JwtSecurityToken(
            issuer: options.ValidIssuer,
            audience: options.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(options.ExpireInMinutes)),
            signingCredentials: signingCredentials);

    public static List<Claim> GetUserClaimsFromToken(string accessToken)
    {
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();   
        JwtSecurityToken token = handler.ReadJwtToken(accessToken);
        return token.Claims.Where(c => c.Type == "FullName" || 
                                  c.Type == ClaimTypes.Name )
                           .ToList();
    }

    public static string GetAccessToken(JwtConfigurationOptions options, List<Claim> userClaims)
    {
        SigningCredentials signingCredentials = GetSigingCredentials(options);
        JwtSecurityToken jwtSecurityToken = GetSecutiryToken(options, signingCredentials, userClaims);
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}
