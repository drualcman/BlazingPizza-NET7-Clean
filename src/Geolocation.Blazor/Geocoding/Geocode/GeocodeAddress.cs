namespace Geolocation.Blazor.Geocoding.Geocode;
internal class GeocodeAddress
{
    public int place_id { get; set; }
    public string licence { get; set; }
    public string powered_by { get; set; }
    public string osm_type { get; set; }
    public long osm_id { get; set; }
    public double lat { get; set; }
    public double lon { get; set; }
    public string display_name { get; set; }
    public Address address { get; set; }

    internal class Address
    {
        public string shop { get; set; }
        public string amenity { get; set; }
        public string road { get; set; }
        public string neighbourhood { get; set; }
        public string village { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string region { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
        public string country_code { get; set; }
    }
}
