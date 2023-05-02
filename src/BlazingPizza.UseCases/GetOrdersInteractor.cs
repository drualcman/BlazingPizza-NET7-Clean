namespace BlazingPizza.UseCases;
internal sealed class GetOrdersInteractor : IGetOrdersInputPort
{
    readonly IBlazingPizzaQueriesRepository Repository; 
    readonly IUserService UserService;

    public GetOrdersInteractor(IBlazingPizzaQueriesRepository repository, IUserService userService)
    {
        Repository = repository;
        UserService = userService;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        UserService.CheckIfIsAuthorizedGuard();
        return await Repository.GetOrdersAsync(UserService.UserId);
    }
}
