namespace Geolocation.Blazor.Geocoding;
public interface IGeocoder
{
    Task<GeolocationAddress> GetGeocodingAddressAsync(double latitude, double longitude);
}
