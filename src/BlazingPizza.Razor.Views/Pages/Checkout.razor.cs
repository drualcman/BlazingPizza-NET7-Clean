namespace BlazingPizza.Razor.Views.Pages;
public partial class Checkout
{
    [Inject] public IOrderStateService OrderState { get; set; }
}
