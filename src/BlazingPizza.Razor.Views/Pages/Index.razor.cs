using BlazingPizza.Shared.BussinesObjects.Agregates;
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
    double Latitude = 15.17304;
    double Longitude = 120.595088;
    string Title = "";
    string Description = "";
    string Message;
    GetOrderDto MyOrder;
    public int OrderId;
    OrderStatusNotification Notification;

    void HandleNotification(OrderStatusNotification notification)
    {
        Notification = notification;
        InvokeAsync(StateHasChanged);
    }

    GetOrderDto GetOrderFake(int id)
    {
        GetOrderDto order = null;
        switch(id)
        {
            case 1:     //nueva orden
                order = new()
                {
                    Id = id,
                    CreatedTime = DateTime.Now,
                    DeliveryLocation = new LatLong() { Latitude =  15.17304, Longitude = 120.585088 }
                }; 
                break;  
            case 2:   //preparacion
                order = new()
                {
                    Id = id,
                    CreatedTime = DateTime.Now.AddSeconds(-5),                    
                    DeliveryLocation = new LatLong() { Latitude =  15.15304, Longitude = 120.597088 }
                }; 
                break;  
            case 3:   //de camino
                order = new()
                {
                    Id = id,
                    CreatedTime = DateTime.Now.AddSeconds(-25),                    
                    DeliveryLocation = new LatLong() { Latitude =  15.14304, Longitude = 120.595088 }
                }; 
                break;  
            case 4:   //de camino
                order = new()
                {
                    Id = id,
                    CreatedTime = DateTime.Now.AddMinutes(-10),
                    DeliveryLocation = new LatLong() { Latitude =  15.16304, Longitude = 120.589088 }
                }; 
                break;
        }
        return order;
    }

    protected override void OnInitialized()
    {
        OriginalPoint = new DrMaps.Blazor.ValueObjects.LatLong(Latitude, Longitude);        
    }

    Task Mostrar() 
    {
        Notification = null;
        MyOrder = GetOrderFake(OrderId);
        return Task.CompletedTask;
    }

    async Task OnMapCreated(Map map)
    {
        MyMap = map;
        await MyMap.SetViewAsync(OriginalPoint, 16);
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
