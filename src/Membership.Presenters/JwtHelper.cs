namespace Membership.Presenters;
internal static class JwtHelper
{
    static SigningCredentials GetSigingCredentials(JwtConfigurationOptions options)
    {
        byte[] key = Encoding.UTF8.GetBytes(options.SecurityKey);
        SymmetricSecurityKey secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    public static List<Claim> GetClaims(UserDto userData) =>
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

    public static List<Claim> GetClaimsFromToken(string accessToken)
    {
        JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();   
        JwtSecurityToken token = handler.ReadJwtToken(accessToken);
        List<Claim> claims = token.Claims.ToList();
        Claim aud = claims.FirstOrDefault(c => c.Type == "aud");
        claims.Remove(aud);
        Claim iss = claims.FirstOrDefault(c => c.Type == "iss");
        claims.Remove(iss);  
        Claim exp = claims.FirstOrDefault(c => c.Type == "exp");
        claims.Remove(exp);
        return claims;
    }

    public static string GetAccessToken(JwtConfigurationOptions options, List<Claim> userClaims)
    {
        SigningCredentials signingCredentials = GetSigingCredentials(options);
        JwtSecurityToken jwtSecurityToken = GetSecutiryToken(options, signingCredentials, userClaims);
        return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
    }
}
