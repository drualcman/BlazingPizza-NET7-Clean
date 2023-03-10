namespace BlazingPizza.UseCases;
internal sealed class PlaceOrderInteractor : IPlaceOrderInputPort
{
    readonly IBlazingPizzaCommandsRepository Repository;
    readonly IValidator<Address> AddressValidator;

    public PlaceOrderInteractor(IBlazingPizzaCommandsRepository repository, IValidator<Address> addressValidator)
    {
        Repository = repository;
        AddressValidator = addressValidator;
    }

    public async Task<int> PlaceOrderAsync(PlaceOrderOrderDto order)
    {
        IValidationResult result = AddressValidator.Validate(order.DeliveryAddress);
        if (!result.IsValid)
        {
            throw new Exception(result.ToString());
        }
        return await Repository.PlaceOrderAsync(order);
    }
}
