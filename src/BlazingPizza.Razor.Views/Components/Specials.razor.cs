namespace BlazingPizza.Razor.Views.Components;

public partial class Specials
{
    [Inject] public ISpecialsViewModel ViewModel { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await ViewModel.GetSpeiclasAsync();
    }

}
