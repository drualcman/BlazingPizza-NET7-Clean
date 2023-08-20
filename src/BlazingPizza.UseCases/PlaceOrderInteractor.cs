using BlazingPizza.Backend.BussinesObjects.Interfaces.PushNotifications;
using Membership.Entities.Interfaces;

namespace BlazingPizza.UseCases;
internal sealed class PlaceOrderInteractor : IPlaceOrderInputPort
{
    readonly IBlazingPizzaCommandsRepository Repository;
    readonly IValidator<Address> AddressValidator;
    readonly IUserService UserService;
    readonly IPushNotificator PushNotificator;

    public PlaceOrderInteractor(IBlazingPizzaCommandsRepository repository, IValidator<Address> addressValidator, IUserService userService, IPushNotificator pushNotificator)
    {
        Repository = repository;
        AddressValidator = addressValidator;
        UserService = userService;
        PushNotificator = pushNotificator;
    }

    public async Task<int> PlaceOrderAsync(PlaceOrderOrderDto order)
    {
        UserService.ThrowIfNotAuthenticated();        
        order.UserId = UserService.UserId;
        AddressValidator.Guard(order.DeliveryAddress);
        int orderId = await Repository.PlaceOrderAsync(order);
        if(order.Subscription is not null)
        {
            PushNotificator.StartNotification(orderId, order.Subscription);
        }
        return orderId;

    }
}
