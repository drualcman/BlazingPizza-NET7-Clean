namespace Geolocation.Blazor;
public class GeolocationService : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> ModuleTask;

    public GeolocationService(IJSRuntime jsRuntime)
    {
        ModuleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/Geolocation.Blazor/geolocation.js").AsTask());
    }

    public async ValueTask<LatLongPosition> GetPositionAsync()
    {
        var module = await ModuleTask.Value;
        LatLongPosition postition = default;
        try
        {
            postition = await module.InvokeAsync<LatLongPosition>("getPositionAsync");

        }
        catch(Exception ex)
        {
            Console.WriteLine($"GetPosition: {ex.Message}");
        }
        return postition;
    }

    public async ValueTask DisposeAsync()
    {
        if(ModuleTask.IsValueCreated)
        {
            var module = await ModuleTask.Value;
            await module.DisposeAsync();
        }
    }
}
