namespace BlazingPizza.Razor.Views.Components;
public partial class LoginDisplay
{
    string ImagePath => $"_content/{GetType().Assembly.GetName().Name}/images";
}
