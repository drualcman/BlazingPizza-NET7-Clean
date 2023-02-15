namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class LatLongMapper
{
    internal static LatLong ToEFLatLong(this BussinesObjects.ValueObjects.LatLong address) =>
        new LatLong
        {
            Latitude= address.Latitude,
            Longitude= address.Longitude
        };

     internal static BussinesObjects.ValueObjects.LatLong ToLatLong(this LatLong address) =>
        new BussinesObjects.ValueObjects.LatLong
        {
            Latitude= address.Latitude,
            Longitude= address.Longitude
        };
}
