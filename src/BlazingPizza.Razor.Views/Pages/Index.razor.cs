using DrMaps.Blazor;
using DrMaps.Blazor.Entities;

namespace BlazingPizza.Razor.Views.Pages;
public partial class Index
{
    [Inject] IIndexViewModel ViewModel { get; set; }
    [Inject] IOrderStateService OrderStateService { get; set; }

    DrMaps.Blazor.ValueObjects.LatLong OriginalPoint { get; set; } = new DrMaps.Blazor.ValueObjects.LatLong(15.192939, 120.586715);
    Map MyMap;
    List<AddressGeocoding> Locations;
    Address LookupAddress = new();

    async Task GetLocations()
    {
        DrMaps.Blazor.ValueObjects.Address geocoding = 
            new DrMaps.Blazor.ValueObjects.Address($"{LookupAddress.AddressLine1} {LookupAddress.AddressLine2}",
                                       LookupAddress.City, LookupAddress.Region, LookupAddress.Postalcode, "");
        await MyMap.DeleteMap();
        Locations = new(await MyMap.GetAddress(geocoding));
        if(Locations is not null && Locations.Any())
        {
            int total = Locations.Count;
            if (total > 0)
            {
                for(int i = 0; i < total; i++)
                {
                    if(i==0) await MyMap.CreateMap(Locations[0].Point);
                    await MyMap.ShowPoint(Locations[i].Point, LookupAddress.Name, Locations[i].DisplayName);
                }
            }
            else
                await MyMap.CreateMap(OriginalPoint);
        }
        else
            await MyMap.CreateMap(OriginalPoint);

    }

}
