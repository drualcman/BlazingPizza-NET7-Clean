namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class LatLongMapper
{
    internal static LatLong ToEFLatLong(this SharedValueObjects.LatLong address) =>
        new LatLong
        {
            Latitude= address.Latitude,
            Longitude= address.Longitude
        };

     internal static SharedValueObjects.LatLong ToLatLong(this LatLong address) =>
        new SharedValueObjects.LatLong(address.Latitude,address.Longitude);
}
