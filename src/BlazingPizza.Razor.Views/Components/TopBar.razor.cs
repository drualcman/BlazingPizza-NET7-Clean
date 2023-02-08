namespace BlazingPizza.Razor.Views.Components;
public partial class TopBar
{
    string ImagePath => $"_content/{GetType().Assembly.GetName().Name}/images";
}
