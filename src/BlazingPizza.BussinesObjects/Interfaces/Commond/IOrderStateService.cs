namespace BlazingPizza.BussinesObjects.Interfaces.Commond;
public interface IOrderStateService
{
    Order Order { get; }
    void ResetOrder();
    void ReplaceOrder(Order order);
}
