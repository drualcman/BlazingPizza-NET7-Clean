using ExceptionHandler.Razor;

namespace BlazingPizza.Razor.Views.Shared;

public partial class MainLayout
{
    CustomErrorBoundary ErrorBoundaryRef;
    void OnExeption(Exception ex)
    {
        Console.WriteLine($"Error en Main Layout: {ex.Message}");
    }

    protected override void OnParametersSet()
    {
        ErrorBoundaryRef?.Recover();
        base.OnParametersSet();
    }
}