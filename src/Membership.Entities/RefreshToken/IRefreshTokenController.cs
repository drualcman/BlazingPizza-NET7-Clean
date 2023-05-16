namespace Membership.Entities.RefreshToken; 
public interface IRefreshTokenController 
{
    ValueTask<UserTokensDto> RefreshTokenAsync(UserTokensDto userTokensDto);
}
