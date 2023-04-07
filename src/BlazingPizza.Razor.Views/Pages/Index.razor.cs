using DrMaps.Blazor;
using DrMaps.Blazor.Entities;

namespace BlazingPizza.Razor.Views.Pages;
public partial class Index
{
    [Inject] IIndexViewModel ViewModel { get; set; }
    [Inject] IOrderStateService OrderStateService { get; set; }

    DrMaps.Blazor.ValueObjects.LatLong OriginalPoint;
    Map MyMap;
    List<PlaceGeocoding> Locations;
    Address LookupAddress = new();
    double Latitude = 15.192939;
    double Longitude = 120.586715;
    string Title = "";
    string Description = "";
    string Message;

    protected override void OnInitialized()
    {
        OriginalPoint = new DrMaps.Blazor.ValueObjects.LatLong(Latitude, Longitude );
    }

    async Task OnMapCreated(Map map)
    {
        MyMap = map;
        await MyMap.AddMarkerAsync(OriginalPoint, "Origen", "Blazing Pizza store");
    }

    async Task AddMarker()
    {
        int index = await MyMap.AddMarkerAsync(new DrMaps.Blazor.ValueObjects.LatLong(Latitude, Longitude), Title, Description);
        Message = $"Market {index} added.";
        await InvokeAsync(StateHasChanged);
    }

    async Task GetLocations()
    {
        DrMaps.Blazor.ValueObjects.Address geocoding =
            new DrMaps.Blazor.ValueObjects.Address($"{LookupAddress.AddressLine1} {LookupAddress.AddressLine2}",
                                       LookupAddress.City, LookupAddress.Region, LookupAddress.Postalcode, "");
        
        Locations = new(await MyMap.GetAddress(geocoding));
        if(Locations is not null && Locations.Any())
        {
            int total = Locations.Count;
            if(total > 0)
            {
                for(int i = 0; i < total; i++)
                {
                    if(i == 0) await MyMap.SetViewAsync(Locations[0].Point);
                    await MyMap.AddMarkerAsync(Locations[i].Point, LookupAddress.Name, Locations[i].DisplayName);
                }
            }
        }

    }

}
