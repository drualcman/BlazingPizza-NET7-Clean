namespace BlazingPizza.Razor.Views.Components;
public partial class TopBar
{                         
    [Inject] public IOrderStateService OrderState { get; set; }
    string ImagePath => $"_content/{GetType().Assembly.GetName().Name}/images";
}
