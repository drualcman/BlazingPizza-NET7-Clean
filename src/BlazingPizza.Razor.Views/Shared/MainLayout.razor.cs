using ExceptionHandler.Razor;

namespace BlazingPizza.Razor.Views.Shared;

public partial class MainLayout
{
    [Inject] NavigationManager navigationManager { get; set; }

    CustomErrorBoundary ErrorBoundaryRef;
    void OnExeption(Exception ex)
    {
        Console.WriteLine($"Error en Main Layout: {ex.Message}");
        if(ex.Message.Contains("401"))
        {
            Task.Run(() =>
            {                   
                navigationManager.NavigateTo("user/login");
            });
        }
    }

    protected override void OnParametersSet()
    {
        ErrorBoundaryRef?.Recover();
        base.OnParametersSet();
    }
}