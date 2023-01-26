namespace BlazingPizza.Models.Services;
public class OrderStateService : IOrderStateService
{
    public Order Order { get; private set; } = new();
    public void ReplaceOrder(Order order) => Order = order;
    public void ResetOrder() => Order = new();

}
