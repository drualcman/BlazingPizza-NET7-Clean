namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class LatLongMapper
{
    internal static LatLong ToEFLatLong(this BussinesObjects.ValueObjects.LatLong address) =>
        new LatLong
        {
            Latitude= address.Latitude,
            Longitude= address.Longitude
        };
}
