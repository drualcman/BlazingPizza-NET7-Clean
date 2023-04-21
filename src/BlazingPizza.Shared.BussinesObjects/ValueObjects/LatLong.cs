namespace BlazingPizza.Shared.BussinesObjects.ValueObjects;
public record LatLong
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }

    public LatLong() { }

    public LatLong(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public static LatLong Interpolate(LatLong start, LatLong end, double proportion)
    {
        double newLatitude = start.Latitude + (end.Latitude - start.Latitude) * proportion;
        double newLongitude = start.Longitude + (end.Longitude - start.Longitude) * proportion;
        return new LatLong(newLatitude, newLongitude);
    }
}
