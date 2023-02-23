namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class LatLongMapper
{
    internal static LatLong ToEFLatLong(this Shared.BussinesObjects.ValueObjects.LatLong address) =>
        new LatLong
        {
            Latitude= address.Latitude,
            Longitude= address.Longitude
        };

     internal static Shared.BussinesObjects.ValueObjects.LatLong ToLatLong(this LatLong address) =>
        new Shared.BussinesObjects.ValueObjects.LatLong
        {
            Latitude= address.Latitude,
            Longitude= address.Longitude
        };
}
