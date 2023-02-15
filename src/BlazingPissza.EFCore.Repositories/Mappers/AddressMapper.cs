namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class AddressMapper
{
    internal static Address ToEFAddress(this BussinesObjects.ValueObjects.Address address) =>
        new Address
        {
            Name = address.Name,
            AddressLine1 = address.AddressLine1,
            AddressLine2 = address.AddressLine2,
            City = address.City,
            Region = address.Region,
            PostalCode = address.Postalcode
        };
    internal static BussinesObjects.ValueObjects.Address ToAddress(this Address address) =>
        new BussinesObjects.ValueObjects.Address
        (
            Name : address.Name,
            AddressLine1 : address.AddressLine1,
            AddressLine2 : address.AddressLine2,
            City : address.City,
            Region : address.Region,
            Postalcode : address.PostalCode
        );
}
