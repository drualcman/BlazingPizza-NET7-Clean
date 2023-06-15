namespace BlazingPizza.FrondEnd.BussinesObjects.Interfaces.Common;
public interface ITokenStateService
{
    Task SetTokensAsync(UserTokensDto userTokensDto);
    Task<UserTokensDto> GetTokensAsync();
    Task RemoveTokensAsync();
}
