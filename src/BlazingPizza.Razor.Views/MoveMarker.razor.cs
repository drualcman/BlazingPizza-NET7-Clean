﻿using DrMaps.Blazor;

namespace BlazingPizza.Razor.Views;
public partial class MoveMarker
{
    #region Variables
    double Latitude = 15.192939;
    double Longitude = 120.586715;
    int Speed = 30;
    double TimeInMinutes = 10;
    double Distance;
    Map Map;  
    DrMaps.Blazor.ValueObjects.LatLong Origin;
    string Message;
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

    async Task GetNewPoint()
    { 
        DrMaps.Blazor.ValueObjects.LatLong newPoint =  Map.CalculateRandomPointNear(Origin, Distance / 1000); 
        await Map.AddMarkerAsync(newPoint, "Customer", "Near to the store");
        double distance = Map.GetDistanceBetween(Origin, newPoint);
        Message = $"Distancia al destino {distance.ToString("0.00")} Km";

    }
}
