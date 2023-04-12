using DrMaps.Blazor;

namespace BlazingPizza.Razor.Views;
public partial class MoveMarker
{
    #region Variables
    double Latitude = 15.192939;
    double Longitude = 120.586715;
    int Speed = 100;
    double TimeInMinutes = 1.5;
    double Distance;
    Map Map;  
    DrMaps.Blazor.ValueObjects.LatLong Origin;
    string Message;
    int Degree;
    #endregion

    #region overrides
    async Task OnCreateMapAsync(Map map)
    {
        Map = map;    
        Origin = new DrMaps.Blazor.ValueObjects.LatLong(Latitude, Longitude);
        await Map.SetViewAsync(Origin, 12);
        await Map.AddMarkerAsync(Origin, "Origin", "Blazing Pizza Store");              
    }
    #endregion

    async Task ComputeDistance()
    {
        Distance = Speed * TimeInMinutes / 60 * 1000;  
        await Map.DrawCircleAsync(Origin, "red", "#f03", 0.5, Distance);
    } 

    async Task GetDestination()
    {
        Degree = new Random().Next(0, 360);
        DrMaps.Blazor.ValueObjects.LatLong destination = new DrMaps.Blazor.ValueObjects.LatLong(Latitude, Longitude)
            .AddMetters(Degree, Distance);
        await Map.AddMarkerAsync(destination, "Customer", "Near to the store", DrMaps.Blazor.ValueObjects.Icon.DESTINATION);
        double distance = Map.GetDistanceInMettersBetween(Origin, destination);
        Message = $"Distancia al destino {(distance / 1000).ToString("0.00")} Km";

    }

    async Task MoveDestinationMarker()
    {
        DrMaps.Blazor.ValueObjects.LatLong origin = new DrMaps.Blazor.ValueObjects.LatLong(Latitude, Longitude);
        int dronID =  await Map.AddMarkerAsync(origin, "Dron", "Dron repartidor", DrMaps.Blazor.ValueObjects.Icon.DRON);
        for(int i = 0; i < Distance; i+=(int)Distance/10)
        {
            await Task.Delay(2000);
            DrMaps.Blazor.ValueObjects.LatLong destination = origin.AddMetters(Degree, i);
            await Map.MoveMarketAsync(dronID, destination);
        }

    }
}
