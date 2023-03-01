namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class AddressMapper
{
    internal static Address ToEFAddress(this SharedValueObjects.Address address) =>
        new Address
        {
            Name = address.Name,
            AddressLine1 = address.AddressLine1,
            AddressLine2 = address.AddressLine2,
            City = address.City,
            Region = address.Region,
            PostalCode = address.Postalcode
        };
    internal static SharedValueObjects.Address ToAddress(this Address address) =>
        new SharedValueObjects.Address
        {
            Name = address.Name,
            AddressLine1 = address.AddressLine1,
            AddressLine2 = address.AddressLine2,
            City = address.City,
            Region = address.Region,
            Postalcode = address.PostalCode
        };
}
