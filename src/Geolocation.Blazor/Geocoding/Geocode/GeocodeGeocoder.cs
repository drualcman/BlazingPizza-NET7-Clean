using System.Net.Http.Json;

namespace Geolocation.Blazor.Geocoding.Geocode;
internal class GeocodeGeocoder : IGeocoder
{
    readonly HttpClient Client;

    public GeocodeGeocoder(HttpClient client)
    {
        Client = client;
    }

    //https://geocode.maps.co/
    public async Task<GeolocationAddress> GetGeocodingAddressAsync(double latitude, double longitude)
    {
        string url = $"https://geocode.maps.co/reverse?{BuildParameters(latitude, longitude)}";
        HttpResponseMessage response = await Client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        GeocodeAddress address = await response.Content.ReadFromJsonAsync<GeocodeAddress>();
        GeolocationAddress result = new GeolocationAddress
        {
            Latitude = address.lat,
            Longitude = address.lon,
            Formatted = address.display_name,
            Country = address.address.country,
            Country_Code = address.address.country_code,
            State = address.address.state,
            Region = address.address.region,
            City = address.address.city,
            PostalCode = address.address.postcode,
            HouseNumber = address.address.village,
            Street = address.address.road,
            AddressLine1 = address.address.amenity,
            AddressLine2 = address.address.neighbourhood,
            ResultType = address.osm_type
        };
        return result;
    }

    string BuildParameters(double latitude, double longitude)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string>
        {
            { "lat", latitude.ToString() },
            { "lon", longitude.ToString() },
            { "format", "json" }
        };
        return string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}").ToArray());
    }

}
