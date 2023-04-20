using System.Net.Http.Json;

namespace Geolocation.Blazor.Geocoding.Geoapify;
internal class GeoapifyGeocoder : IGeocoder
{
    // https://apidocs.geoapify.com/docs/geocoding/reverse-geocoding/#about
    // test api: 1b48259b810e48ddb151889f9ea58db0
    readonly HttpClient Client;
    readonly string ApiKey;

    public GeoapifyGeocoder(HttpClient client, string apiKey)
    {
        Client = client;
        ApiKey = apiKey;
    }

    public async Task<GeolocationAddress> GetGeocodingAddressAsync(double latitude, double longitude)
    {
        const string baseUri = "https://api.geoapify.com/v1/geocode/reverse";
        HttpResponseMessage response = await Client.GetAsync($"{baseUri}?{BuildParameters(latitude, longitude, ApiKey)}");
        response.EnsureSuccessStatusCode();
        GeoapifyResult geoapiResult = await response.Content.ReadFromJsonAsync<GeoapifyResult>();
        GeoapifyAddress address = geoapiResult.Results[0];
        GeolocationAddress result = new GeolocationAddress
        {
            Latitude = address.lat,
            Longitude = address.lon,
            ResultType = address.result_type,
            Formatted = address.formatted,
            Country = address.country,
            Country_Code = address.country_code,
            State = address.state,
            Region = address.region,
            City = address.city,
            PostalCode = address.postcode,
            Street = address.street,
            HouseNumber = address.housenumber,
            AddressLine1 = address.address_line1,
            AddressLine2 = address.address_line2,
        };
        return result;
    }

    string BuildParameters(double latitude, double longitude, string apiKey)
    {
        Dictionary<string, string> parameters = new Dictionary<string, string> 
        {
            { "lat", latitude.ToString() },
            { "lon", longitude.ToString() },
            { "format", "json" },
            { "type", "building" },
            { "limit", "1" },
            { "apiKey", apiKey }
        };
        return string.Join("&", parameters.Select(p => $"{p.Key}={p.Value}").ToArray());
    }
}
