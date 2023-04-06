using Microsoft.AspNetCore.Components;

namespace Leaflet.Blazor
{
    public partial class Map : IAsyncDisposable
    {
        #region inyeccion de servicios
        [Inject] LeafletService LeafletService { get; set; }
        #endregion

        #region Parametros
        [Parameter] public LatLong OriginalPoint { get; set; } = new LatLong(15.192939, 120.586715);
        [Parameter] public byte ZoomLevel { get; set; } = 17;
        #endregion

        #region variables
        string MapId = $"map-{Guid.NewGuid()}";
        bool IsMapReady = false;
        #endregion

        #region Overrides
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if(firstRender)
            {
                try
                {
                    await LeafletService.InvokeVoidAsync("createMap", MapId, OriginalPoint, ZoomLevel);
                    await LeafletService.InvokeVoidAsync("addMarker", MapId, OriginalPoint, "Mi Casita", "La mas bonita");
                }
                catch(Exception ex)
                {
                    await Console.Out.WriteAsync(ex.ToString());
                }
                IsMapReady = true;
                await InvokeAsync(StateHasChanged);
            }
        }

        public async ValueTask DisposeAsync()
        {   
            await LeafletService.InvokeVoidAsync("deleteMap", MapId);
        }
        #endregion
    }
}