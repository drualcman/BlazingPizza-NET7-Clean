namespace Geolocation.Blazor.Geocoding;
public class GeoapifyAddress
{
    public string name { get; set; }
    public string country { get; set; }
    public string country_code { get; set; }
    public string region { get; set; }
    public string state { get; set; }
    public string city { get; set; }
    public string village { get; set; }
    public string postcode { get; set; }
    public string street { get; set; }
    public string housenumber { get; set; }
    public double lon { get; set; }
    public double lat { get; set; }
    public double distance { get; set; }
    public string result_type { get; set; }
    public string county { get; set; }
    public string formatted { get; set; }
    public string address_line1 { get; set; }
    public string address_line2 { get; set; }
    public string category { get; set; }
    public string place_id { get; set; }
}
